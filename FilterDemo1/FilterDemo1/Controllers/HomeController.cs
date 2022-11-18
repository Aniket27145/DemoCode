using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Filterdemo1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Filterdemo1.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Login(Users user)
        {
            var users = new Users();
            if (users.GetUsers().Any(u => u.Username == user.Username &&
            u.Password == user.Password))
            {
                var userClaims = new List<Claim>()
        {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, "admin@mail.com"),
        };

                var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", new Users());
        }
    }
}