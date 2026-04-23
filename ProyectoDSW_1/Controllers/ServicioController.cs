using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicio _servicioDao;

        public ServicioController(IServicio servicioDao)
        {
            _servicioDao = servicioDao;
        }

        [HttpGet("getServicios")]
        public ActionResult GetServicios()
        {
            return Ok(_servicioDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetServicio(int id)
        {
            var servicio = _servicioDao.Buscar(id);

            if (servicio == null)
                return NotFound();

            return Ok(servicio);
        }

        [HttpPost("saveServicio")]
        public ActionResult SaveServicio(Servicio servicio)
        {
            _servicioDao.Registrar(servicio);
            return Created("", servicio);
        }

        [HttpPut("updateServicio")]
        public ActionResult UpdateServicio(Servicio servicio)
        {
            _servicioDao.Actualizar(servicio);
            return Ok(servicio);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteServicio(int id)
        {
            _servicioDao.Eliminar(id);
            return Ok();
        }

    }
}
