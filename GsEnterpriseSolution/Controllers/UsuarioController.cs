using Microsoft.AspNetCore.Mvc;

namespace GsEnterpriseSolution.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet("cadastrar/{loginId}")]
        public IActionResult Cadastrar([FromRoute] int loginId)
        {
            return View();
        }
    }
}
