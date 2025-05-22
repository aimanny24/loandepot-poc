using Microsoft.AspNetCore.Mvc;

namespace TestAutomationPOCSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password123")
                return View("Dashboard");

            ViewBag.Message = "Invalid username or password.";
            return View("Index");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}