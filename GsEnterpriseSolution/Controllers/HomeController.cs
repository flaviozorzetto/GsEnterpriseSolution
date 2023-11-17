using Microsoft.AspNetCore.Mvc;

namespace GsEnterpriseSolution.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var cookies = HttpContext.Request.Cookies;
            var userData = cookies.Where(x => x.Key == "user-data").Select(x => x.Key).FirstOrDefault();

            return View(userData);
        }
    }
}
