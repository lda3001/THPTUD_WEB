using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH_Harmic.Utilities;

namespace TH_Harmic.Areas.Admin.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
