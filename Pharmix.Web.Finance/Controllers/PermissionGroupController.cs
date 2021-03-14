using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Entities;
using Pharmix.Web.Models;
using Pharmix.Web.Models.ManageViewModels;
using Pharmix.Web.Services;

namespace Pharmix.Web.Controllers
{
    public class PermissionGroupController : BaseController
    {
        private readonly IPermissionGroupService _permisisonGroupService;
        private readonly ITrustService _trustService;
        public PermissionGroupController(UserManager<ApplicationUser> userManager, IPermissionGroupService permisisonGroupService,
            ITrustService trustService
            ) : base(userManager)
        {
            _permisisonGroupService = permisisonGroupService;
            _trustService = trustService;
        }
        public IActionResult Index()
        {
            var model = new SearchViewModel() { };
            return View(model);
        }

        public ActionResult Search(SearchRequest request)
        {
            var model = _permisisonGroupService.GetSearchResult(request);
            return PartialView("DisplayTemplates/GridViewModel", model);
        }

        // GET: Sites/Details/5
        public ActionResult Get(int id)
        {
            var model = _permisisonGroupService.CreateViewModel(id);
            if (id <= 0)
            {       //Create new 
                var trustId = _trustService.GetTrustIdByUser(CurrentUserName);
                if (trustId <= 0)   //If SuperAdminUser. Need to show in DDL
                    trustId = _trustService.GetAllTrusts().FirstOrDefault().Id;
                model.TrustId = trustId;
            }
            return PartialView("_GroupForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save(GroupViewModel model)
        {

            if (ModelState.IsValid)
            {
                var response = _permisisonGroupService.MapViewModelToGroup(model, CurrentUserName, true);

                return Json(new { StatusCode = response > 0 ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, Message = response > 0 ? (model.Id>0 ?"Updated successfully":"Created successfully") : "Not updated" });
            }
            else
                return Json(new { StatusCode =  StatusCodes.Status500InternalServerError, Message ="Not updated" });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _permisisonGroupService.ArchiveGroup(id, CurrentUserName);
            return Json(new { StatusCode=result?StatusCodes.Status200OK:StatusCodes.Status500InternalServerError, Message=result?"Delete successfully":"Not updated"});
        }


        #region Assign Permission to group

        public ActionResult ManagePermission(int id)
        {
            var groupViewModel = _permisisonGroupService.CreateViewModel(id);

            var permissionViewModelList = _permisisonGroupService.GetPermissionsByGroup(id);
            permissionViewModelList = permissionViewModelList.Select(x => { x.IsSelected = true; return x; }).ToList();
            var availablePermissionViewModelList = _permisisonGroupService.GetNotAssignedChildPermissions(trustId: groupViewModel.TrustId); //Permissions which are not assigned to any group

            groupViewModel.PermissionViewModelList = new List<PermissionViewModel>();

            if (permissionViewModelList != null)
                groupViewModel.PermissionViewModelList.AddRange(permissionViewModelList);
            if (availablePermissionViewModelList != null)
            {
                var addedPermissionIds = groupViewModel.PermissionViewModelList.Select(x => x.Id).ToList();
                groupViewModel.PermissionViewModelList.AddRange(availablePermissionViewModelList.Where(x => !addedPermissionIds.Contains(x.Id)));
            }

            return View(groupViewModel);
        }

        [HttpPost]
        public ActionResult ManagePermission(GroupViewModel groupViewModel)
        {
            string message = string.Empty;
            try
            {
                _permisisonGroupService.UpdatePermissionGroup(groupViewModel);
                message = "Updated successfully";
            }
            catch 
            {
                message = "Not updated";
            }
            ViewBag.ManagePermissionSavedMessage = message;
            return View(groupViewModel);
        }

        #endregion

    }

}