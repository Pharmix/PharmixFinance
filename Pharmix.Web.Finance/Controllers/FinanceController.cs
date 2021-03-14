using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmix.Web.Entities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pharmix.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FinanceController : BaseController
    {
        public FinanceController(UserManager<ApplicationUser> userManager) : base(userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult PremiumCalculator()
        {
            return PartialView("_PremiumCalculator");
        }
    }
}