using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Data.Enums;
using Pharmix.Services;
using Pharmix.Web.Entities;
using Pharmix.Web.Entities.ViewModels;
using Pharmix.Web.Models;
using Pharmix.Web.Services;

namespace Pharmix.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CustomerController : BaseController
    {

        private readonly ICustomerService _customerService;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IModuleService _moduleService;
        private readonly IUserService _userService;

        private string _tempCustomerContactKey = "CustomerContacts";

        private string superAdminRole = "SuperAdmin";

        #region Constructor

        public CustomerController(ICustomerService customerService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager,
            IModuleService moduleService, IUserService userService)
            : base(userManager)
        {
            _customerService = customerService;
            _userManager = userManager;
            _signManager = signManager;
            _moduleService = moduleService;
            _userService = userService;
        }

        #endregion


        public IActionResult Index()
        {
            TempData[_tempCustomerContactKey] = string.Empty;
            var model = new SearchViewModel() { };
            return View(model);
        }
        public ActionResult Search(SearchRequest request)
        {
            var model = _customerService.GetSearchResult(request);
            return PartialView("DisplayTemplates/GridViewModel", model);
        }

        public ActionResult Get(int id)
        {
            TempData[_tempCustomerContactKey] = string.Empty;
            var model = _customerService.CreateViewModel(id);
            return PartialView("_CustomerForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel model)
        {
            if (TempData[_tempCustomerContactKey] != null && TempData[_tempCustomerContactKey].ToString() != "")
            {
                string jsonStr = TempData[_tempCustomerContactKey].ToString();
                model.CustomerContactViewModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerContactViewModel>>(jsonStr);// (List<CustomerContactViewModel>)TempData[_tempCustomerContactKey];
            }
            TempData[_tempCustomerContactKey] = string.Empty;

            if (ModelState.IsValid)
            {
                var response = _customerService.MapViewModelToCustomer(model, CurrentUserName, true);

                return Json(response);
            }
            else
                return Json(false);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(_customerService.ArchiveCustomer(id, CurrentUserName));
        }

        /// <summary>
        /// Add cusomter contact to temp data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contactNumber"></param>
        /// <returns></returns>
        public ActionResult AddCustomerContact(CustomerContactViewModel customerContactViewModel)
        {
            //List<CustomerContactViewModel> customerContactViewModelList=new List<CustomerContactViewModel>();
            //return PartialView("_CustomerContacts", customerContactViewModelList);
            List<CustomerContactViewModel> customerContactViewModelList;
            int maxId = 0;
            if (TempData[_tempCustomerContactKey] != null && TempData[_tempCustomerContactKey].ToString() != "")
            {
                string jsonStr = TempData[_tempCustomerContactKey].ToString();
                customerContactViewModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerContactViewModel>>(jsonStr);// (List<CustomerContactViewModel>)TempData[_tempCustomerContactKey];
                maxId = customerContactViewModelList.Max(x => x.TempId);
            }
            else
                customerContactViewModelList = new List<CustomerContactViewModel>();
            if (!string.IsNullOrEmpty(customerContactViewModel.ContactNumber) && !string.IsNullOrEmpty(customerContactViewModel.Name))
                customerContactViewModelList.Add(new CustomerContactViewModel() { ContactNumber = customerContactViewModel.ContactNumber, Name = customerContactViewModel.Name, TempId = ++maxId });

            TempData[_tempCustomerContactKey] = Newtonsoft.Json.JsonConvert.SerializeObject(customerContactViewModelList);
            return PartialView("_CustomerContacts", customerContactViewModelList);
        }

        public ActionResult DeleteTempCustomerContact(int customerContactTempId)
        {
            List<CustomerContactViewModel> customerContactViewModelList = new List<CustomerContactViewModel>();

            if (customerContactTempId > 0 && TempData[_tempCustomerContactKey] != null && TempData[_tempCustomerContactKey].ToString() != "")
            {
                customerContactViewModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerContactViewModel>>(TempData[_tempCustomerContactKey].ToString());

                var item = customerContactViewModelList.Where(x => x.TempId == customerContactTempId).FirstOrDefault();
                customerContactViewModelList.Remove(item);
                customerContactViewModelList = customerContactViewModelList.Select((x, idx) => { x.TempId = ++idx; return x; }).ToList();   //Resetting the TempId
                TempData[_tempCustomerContactKey] = Newtonsoft.Json.JsonConvert.SerializeObject(customerContactViewModelList);
            }
            else
                TempData.Keep("CustomerContacts");
            return PartialView("_CustomerContacts", customerContactViewModelList);
        }

        public ActionResult GetCustomerContact(int customerId, bool isIncludeItself = false)
        {
            if (customerId > 0)
            {//View Only
                ViewBag.IsViewOnly = true;
                List<CustomerContactViewModel> customerContactViewModelList = new List<CustomerContactViewModel>();
                if (!isIncludeItself)
                {
                    customerContactViewModelList = _customerService.GetCustomerContactsByCustomer(customerId);
                }
                else
                {
                    var customerModel = _customerService.CreateViewModel(customerId);
                    customerContactViewModelList.Add(new CustomerContactViewModel() { Id = customerModel.Id, CustomerId = customerModel.Id, Name = customerModel.LeaderName, ContactNumber = customerModel.ContactNumber });
                    if (customerModel.CustomerContactViewModelList != null && customerModel.CustomerContactViewModelList.Count() > 0)
                        customerContactViewModelList.AddRange(customerModel.CustomerContactViewModelList);
                }
                return PartialView("_CustomerContacts", customerContactViewModelList);
            }
            else
            {
                //Add and delete
                CustomerContactViewModel customerContactViewModel = new CustomerContactViewModel();
                if (TempData[_tempCustomerContactKey] != null && TempData[_tempCustomerContactKey].ToString() != "")
                {
                    string jsonStr = TempData[_tempCustomerContactKey].ToString();
                    var customerContactViewModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerContactViewModel>>(jsonStr);// (List<CustomerContactViewModel>)TempData[_tempCustomerContactKey];
                    ViewBag.CustomerContacts = customerContactViewModelList;
                    TempData.Keep(_tempCustomerContactKey);
                }
                return PartialView("_CustomerContactForm", customerContactViewModel);
            }
        }


        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return View();
        //    //var model = _customerService.CreateCustomerViewModel(0);
        //    //return View("RegistrationForm", model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public async Task<ActionResult> Register(CustomerViewModel model)
        //{
        //    //_customerService.MapViewModelToCustomer(model, CurrentUserName, true);

        //    var user = new ApplicationUser { UserName = model.EmailAddress, Email = model.EmailAddress };
        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    //if (result.Succeeded)
        //    //   await _userManager.AddToRoleAsync(user, "Customer");

        //    ViewBag.IsSuccess = result.Succeeded;

        //    return View("RegistrationSuccess");
        //}

        /// <summary>
        /// pharmix.admin@pharmixtech.com
        /// Admin@123
        /// </summary>
        /// <returns></returns>
        //public async Task<ViewResult> ManageCustomer()
        //{
        //    var users= await _userService.GetUsersByRole(superAdminRole);
        //    return View();
        //}

        //public async Task<ViewResult> ManageModule(int customerID)
        //{
        //    var modules= _moduleService.GetAllModules();

        //    var moduleModelList = Mapper.Map<List<Module>, List<ModuleViewModel>>(modules.ToList());

        //    CustomerViewModel customerViewModel = new CustomerViewModel() { ModuleViewModelList=moduleModelList };

        //    return View(moduleModelList);
        //}
        //[HttpPost]
        //public async Task<ActionResult> ManageModuel(CustomerViewModel model)
        //{
        //    return View();
        //}
    }
}