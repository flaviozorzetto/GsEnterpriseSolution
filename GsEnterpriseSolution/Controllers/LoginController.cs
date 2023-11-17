using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace GsEnterpriseSolution.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Login login)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
