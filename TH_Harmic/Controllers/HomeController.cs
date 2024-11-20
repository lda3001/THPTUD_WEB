using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TH_Harmic.Models;

namespace TH_Harmic.Controllers
{
    public class HomeController : Controller
    {
        private readonly Th2Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController (Th2Context context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.productCategories= _context.TbProductCategories.ToList();
            ViewBag.productNew= _context.TbProducts.Where(m=>m.IsNew).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
