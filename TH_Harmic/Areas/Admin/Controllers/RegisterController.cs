using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;
using TH_Harmic.Utilities;

namespace TH_Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly Th2Context _context;
        Function function = new Function();
        public RegisterController(Th2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TbAccount account)
        {
            if (account == null)
            {
                return BadRequest();
            }

            var acc = _context.TbAccounts.Where(m => m.Email == account.Email).FirstOrDefault();
            if (acc != null)
            {
                Function.msg = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
           
            account.Password = function.HashPassword(account.Password);
            _context.TbAccounts.Add(account);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
