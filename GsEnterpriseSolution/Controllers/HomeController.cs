using GsEnterpriseSolution.Contexts;
using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GsEnterpriseSolution.Controllers
{
    public class HomeController : Controller
    {
        private PlataformaContext _context;
        public HomeController(PlataformaContext context)
        {
            _context = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var cookies = HttpContext.Request.Cookies;
            string? userData = cookies.Where(x => x.Key == "user-data").Select(x => x.Value).FirstOrDefault();
            if (userData == null)
            {
                return View();
            }

            var login = JsonConvert.DeserializeObject<Login>(userData);

            var foundUser = _context.Usuarios
                .Include(x => x.Login)
                .Include(x => x.Endereco)
                .Include(x => x.Contatos)
                .Where(x => x.Login != null && x.Login.Id == login.Id)
                .FirstOrDefault();
            
            var foundProfissional = _context.Profissionais
                .Include(x => x.Login)
                .Where(x => x.Login != null && x.Login.Id == login.Id)
                .FirstOrDefault();

            if (foundUser == null && foundProfissional == null)
            {
                return View(login);
            }

            if(foundUser != null)
            {
                return View("WithUser", foundUser);
            }
            
            if(foundProfissional != null)
            {
                return View("WithProfessional", foundProfissional);
            }

            return View(login);
        }
    }
}
