using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Controllers;
using Pharmix.Web.Entities;
using Pharmix.Web.Services;

namespace Pharmix.Web.Finance.Controllers
{
    public class BankAccountController : BaseController
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountController(IBankAccountService bankAccountService, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            this._bankAccountService = bankAccountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int customerId)
        {
            var model = new BankAccountViewModel();
            model.CustomerId = customerId;
            return PartialView("_BankAccountForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(BankAccountViewModel model)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            int bankId = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    bankId = _bankAccountService.MapViewModelToBAnkAccount(model, CurrentUserName, true);
                }
            }
            catch (Exception e)
            {
            }
            if (bankId < 0)
                statusCode = HttpStatusCode.InternalServerError;
            return Json(new { StatusCode = (int)statusCode, BankId = bankId, AccountNumber = model.AccountNumber });
        }
    }
}