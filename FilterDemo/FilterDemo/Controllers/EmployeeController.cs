using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.Controllers
{
    public class EmployeeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.Msg1 = "Authorize Users";
            return View();
        }
        [Authorize]
        public IActionResult Registration()
        {
            ViewBag.Msg2 = "Registration";
            // return RedirectToAction("Login"); 
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.Msg3 = "Welcome";
            return View();
        }

       
    }
}
