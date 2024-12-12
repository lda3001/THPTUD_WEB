using Azure.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TH_Harmic.Models;
using TH_Harmic.Utilities;

namespace TH_Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Th2Context _context;
        Function function = new Function();
        public AccountController(Th2Context context)
        {
            _context = context;
        }
        [Route("/Auth/Login")]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home"); 
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Route("/Auth/Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        [Route("/Auth/Login")]

        public async Task<IActionResult> Login(TbAccount account,string returnUrl = null)
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
                
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true }; 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) { 
                    return Redirect(returnUrl); 
                }
                else { return RedirectToAction("Index", "Home");
                }
                

                
            }


            Function.msg = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác";
             return RedirectToAction("Login", "Account"); ;
        }
        [HttpPost]
        [Route("/Auth/Register")]
        public IActionResult Register(TbAccount account)
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
            return RedirectToAction("Login", "Account"); ;
        }
    }
}
