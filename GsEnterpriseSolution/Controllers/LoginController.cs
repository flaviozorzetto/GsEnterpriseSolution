using GsEnterpriseSolution.Contexts;
using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace GsEnterpriseSolution.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private PlataformaContext _context;
        public LoginController(PlataformaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var foundLogin = _context.Logins.Where(x => x.Email == login.Email && x.Senha == login.Senha).FirstOrDefault();

            if(foundLogin == null)
            {
                TempData["msg"] = "Login não encontrado";
                return RedirectToAction("Index");
            }

            string jsonLogin = JsonConvert.SerializeObject(foundLogin);
            HttpContext.Response.Cookies.Append("user-data", jsonLogin);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            var cookies = HttpContext.Request.Cookies;

            if(cookies.Where(x => x.Key == "user-data").Select(x => x.Key).FirstOrDefault() != null)
            {
                HttpContext.Response.Cookies.Delete("user-data");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("cadastrar")]
        public IActionResult Add(Login login)
        {
            var foundLogin = _context.Logins.Where(x => x.Email == login.Email).FirstOrDefault();

            if (foundLogin != null)
            {
                TempData["msg"] = "Já existe um registro de login com este email";
                return RedirectToAction("Index");
            }

            _context.Logins.Add(login);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

    }
}
