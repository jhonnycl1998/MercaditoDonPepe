using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : Controller
    {
        private readonly ITienda _tiendaDao;

        public TiendaController(ITienda tiendaDao)
        {
            _tiendaDao = tiendaDao;
        }

        [HttpGet("getTiendas")]
        public ActionResult GetTiendas()
        {
            return Ok(_tiendaDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetTienda(int id)
        {
            var tienda = _tiendaDao.Buscar(id);

            if (tienda == null)
                return NotFound();

            return Ok(tienda);
        }

        [HttpPost("saveTienda")]
        public ActionResult SaveTienda(Tienda tienda)
        {
            _tiendaDao.Registrar(tienda);
            return Created("", tienda);
        }

        [HttpPut("updateTienda")]
        public ActionResult UpdateTienda(Tienda tienda)
        {
            _tiendaDao.Actualizar(tienda);
            return Ok(tienda);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTienda(int id)
        {
            _tiendaDao.Eliminar(id);
            return Ok();
        }

    }
}
