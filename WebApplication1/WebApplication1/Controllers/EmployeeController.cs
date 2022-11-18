using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
   // [Route("E")]
    public class EmployeeController : Controller
    {
        // GET: Employee
        
        [Route("students")]
        public ActionResult Emp()
        {
            return View();
        }
    }
}