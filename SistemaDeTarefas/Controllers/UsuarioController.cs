using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using System.Diagnostics.CodeAnalysis;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Usuario>> BuscarTodosUsuarios()
        {
            return Ok(); 
        }
    }
}
