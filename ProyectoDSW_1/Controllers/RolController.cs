using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : Controller
    {

        private readonly IRol _rolDao;

        // Inyección correcta
        public RolController(IRol rolDao)
        {
            _rolDao = rolDao;
        }

        [HttpGet("getRoles")]
        public ActionResult GetRoles()
        {
            return Ok(_rolDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetRol(int id)
        {
            var rol = _rolDao.Buscar(id);

            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        [HttpPost("saveRol")]
        public ActionResult SaveRol(Rol rol)
        {
            _rolDao.Registrar(rol);
            return Created("", rol);
        }

        [HttpPut("updateRol")]
        public ActionResult UpdateRol(Rol rol)
        {
            _rolDao.Actualizar(rol);
            return Ok(rol);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRol(int id)
        {
            _rolDao.Eliminar(id);
            return Ok();
        }

    }
}
