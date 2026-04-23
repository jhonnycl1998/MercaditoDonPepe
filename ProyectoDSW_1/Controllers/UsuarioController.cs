using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuario _usuarioDao;

        public UsuarioController(IUsuario usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        [HttpGet("getUsuarios")]
        public ActionResult GetUsuarios()
        {
            return Ok(_usuarioDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetUsuario(int id)
        {
            var usuario = _usuarioDao.Buscar(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost("saveUsuario")]
        public ActionResult SaveUsuario(Usuario usuario)
        {
            var hasher = new PasswordHasher<Usuario>();

            usuario.contraseñaHash = hasher.HashPassword(usuario, usuario.contraseñaHash);

            _usuarioDao.Registrar(usuario);
            return Created("", usuario);
        }

        [HttpPut("updateUsuario")]
        public ActionResult UpdateUsuario(Usuario usuario)
        {
            _usuarioDao.Actualizar(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            _usuarioDao.Eliminar(id);
            return Ok();
        }
    }
}
