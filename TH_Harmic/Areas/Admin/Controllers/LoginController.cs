using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;
using TH_Harmic.Utilities;

namespace TH_Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly Th2Context _context;
        Function function = new Function();
        public LoginController(Th2Context context)
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
            IActionResult response = Unauthorized();

            if (account == null)
            {
                return BadRequest();
            }
          
            var user = _context.TbAccounts.Where(u => u.Email == account.Email).FirstOrDefault();
           

            if (user != null && function.VerifyPassword(account.Password, user.Password))
            {
                Function.account = user;
               
                    return RedirectToAction("Index", "Home");
                
            }


            Function.msg = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác";
             return RedirectToAction("Index", "Login"); ;
        }
    }
}
