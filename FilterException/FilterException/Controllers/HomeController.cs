using FilterException.Exceptions;
using FilterException.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FilterException.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [CatchError]
        public IActionResult Exception( int? id)
        {
            if (id == null)
                throw new Exception("Error Id cannot be null");
            else
                return View("plz  check the exception");

        }

        [System.Web.Mvc.OutputCache]
        public IActionResult Action()
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