using Microsoft.AspNetCore.Mvc;
using TH_Harmic.Utilities;

namespace TH_Harmic.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            if(Function.account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
