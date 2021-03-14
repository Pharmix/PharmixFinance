using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Entities;
using Pharmix.Web.Models.DepartmentViewModels;
using Pharmix.Web.Services;

namespace Pharmix.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly ITrustService trustService;

        public DepartmentController(UserManager<ApplicationUser> userManager, ITrustService trustService) : base(userManager)
        {
            this.trustService = trustService;
        }
        public IActionResult Index()
        {
            var model = new DepartmentIndexViewModel
            {
                TrustId = trustService.GetTrustIdByUser(CurrentUserName),
                IsPharmixAdminRequest = IsPharmixAdmin
            };

            if (IsPharmixAdmin)
                model.TrustList = new SelectList(trustService.GetAllTrusts(), "Id", "Name");

            return View(model);
        }

        public ActionResult Search(SearchRequest request, int trustId)
        {
            return PartialView("DisplayTemplates/GridViewModel", trustService.GetDepartmentSearchResult(request, trustId));
        }

        public ActionResult Get(int id, int trustId)
        {
            var model = trustService.CreateDepartmentViewModel(id);
            model.IsPharmixAdminRequest = IsPharmixAdmin;

            if (!IsPharmixAdmin) return PartialView("_DepartmentDetail", model);

            model.TrustList = new SelectList(trustService.GetAllTrusts(), "Id", "Name");
            model.TrustId = model.TrustId > 0 ? model.TrustId : trustId;

            return PartialView("_DepartmentDetail", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { IsSuccess = false, IsModelError= true, Message = "Model validation failed.", Field = "DepartmentName" });

            if (model.TrustId == 0)
            {
                return Json(new { IsSuccess = false, IsModelError = true, Message = "The Trust field is required.", Field= "TrustId" });
            }
            
            var hasDuplicateDept =
                trustService.CheckDuplicateDepartment(model.DepartmentId, model.DepartmentName, model.TrustId);

            if (hasDuplicateDept)
            {
                return Json(new { IsSuccess = false, IsModelError = true, Message = "Duplicate department name found.", Field = "DepartmentName" });
            }

            var response = trustService.MapViewModelToDepartemnt(model, CurrentUserName);

            return response>0?
                Json(new { IsSuccess = true, Message = "Department saved successfully." }) :
            Json(new { IsSuccess = false, Message = "Department save failed." });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(trustService.ArchiveDepartment(id, CurrentUserName));
        }
    }
}