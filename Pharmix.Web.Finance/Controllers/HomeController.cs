using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pharmix.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pharmix.Web.Entities;

namespace Pharmix.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager) : base(userManager)
        {
        }

        [Authorize]
        public IActionResult Index(int trustId = 0)
        {
            ViewBag.IsPharmixAdmin = IsPharmixAdmin;
            if (IsPharmixAdmin)
            {
                if (trustId == 0) return RedirectToAction("Login", "Account");
                HttpContext.Session.SetInt32("TrustID", trustId);
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
