using GsEnterpriseSolution.Contexts;
using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GsEnterpriseSolution.Controllers
{
    [Route("api/[controller]")]
    public class ProfissionalController : Controller
    {
        private PlataformaContext _context;

        public ProfissionalController(PlataformaContext context)
        {
            _context = context;
        }

        [HttpGet("cadastrar/{loginId}")]
        public IActionResult Index([FromRoute] int loginId)
        {
            TempData["loginId"] = loginId;

            return View("Cadastrar");
        }

        [HttpGet("{id}")]
        public IActionResult Info([FromRoute] int id)
        {
            var profissional = _context.Profissionais
                .Include(x => x.Login)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(profissional);
        }


        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Profissional profissional)
        {
            var login = _context.Logins.Where(x => x.Id == profissional.Login.Id).FirstOrDefault();
            profissional.Login = login;

            _context.Profissionais.Add(profissional);
            _context.SaveChanges();

            TempData["msg"] = "Profissional cadastrado com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var profissional = _context.Profissionais
                .Include(x => x.Login)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(profissional);
        }

        [HttpPost]
        public IActionResult Edit(Profissional profissional)
        {
            _context.Profissionais.Update(profissional);
            _context.SaveChanges();

            TempData["msg"] = "Profissional editado com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("index", "home");
        }

        [HttpGet("pacientes")]
        public IActionResult ListPacientes(string filtro)
        {
            var usuarios = _context.Usuarios
                .Include(x => x.Endereco)
                .Include(x => x.Login)
                .Include(x => x.Contatos)
                .ToList();

            if(filtro != null)
            {
                TempData["filtro"] = filtro;
                var regex = new Regex(filtro, RegexOptions.IgnoreCase);
                usuarios = usuarios.Where(x => regex.IsMatch(x.Nome)).ToList();
            }

            return View(usuarios);
        }
    }
}
