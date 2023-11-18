using GsEnterpriseSolution.Contexts;
using GsEnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GsEnterpriseSolution.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private PlataformaContext _context;

        public UsuarioController(PlataformaContext context)
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
            var usuario = _context.Usuarios
                .Include(x => x.Endereco)
                .Include(x => x.Login)
                .Include(x => x.Contatos)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(usuario);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            var login = _context.Logins.Where(x => x.Id == usuario.Login.Id).FirstOrDefault();
            usuario.Login = login;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["msg"] = "Usuario cadastrado com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios
                .Include(x => x.Endereco)
                .Include(x => x.Login)
                .Include(x => x.Contatos)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            TempData["msg"] = "Usuario editado com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("index", "home");
        }

        [HttpGet("contact")]
        public IActionResult Contact(int id)
        {
            TempData["UsuarioId"] = id;
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(Contato contato, int id)
        {
            var usuario = _context.Usuarios
                .Include(x => x.Endereco)
                .Include(x => x.Login)
                .Include(x => x.Contatos)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            contato.Id = 0;
            usuario.Contatos.Add(contato);

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            TempData["msg"] = "Contato adicionado com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("index", "home");
        }

        [HttpPost("contact/{usuarioId}/{id}")]
        public IActionResult Contact(int usuarioId, int id)
        {
            var foundUsuario = _context.Usuarios
                .Include(x => x.Endereco)
                .Include(x => x.Login)
                .Include(x => x.Contatos)
                .Where(x => x.Id == usuarioId)
                .FirstOrDefault();

            var contato = foundUsuario.Contatos.Where(x => x.Id == id).FirstOrDefault();
            foundUsuario.Contatos.Remove(contato);

            _context.Usuarios.Update(foundUsuario);
            _context.SaveChanges();

            TempData["msg"] = "Contato removido com sucesso";
            TempData["success"] = "1";

            return RedirectToAction("index", "home");
        }
    }
}
