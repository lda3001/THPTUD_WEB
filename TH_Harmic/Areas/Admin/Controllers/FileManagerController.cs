using Microsoft.AspNetCore.Mvc;

namespace TH_Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
