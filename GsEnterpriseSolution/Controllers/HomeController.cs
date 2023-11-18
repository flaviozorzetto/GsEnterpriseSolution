using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GsEnterpriseSolution.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var cookies = HttpContext.Request.Cookies;
            string? userData = cookies.Where(x => x.Key == "user-data").Select(x => x.Value).FirstOrDefault();
            var login = JsonConvert.DeserializeObject<Login>(userData);

            return View(login);
        }
    }
}
