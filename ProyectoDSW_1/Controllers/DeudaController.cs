using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeudaController : Controller
    {
        private readonly IDeuda _deudaDao;

        public DeudaController(IDeuda deudaDao)
        {
            _deudaDao = deudaDao;
        }

        [HttpGet("getDeudas")]
        public ActionResult GetDeudas()
        {
            return Ok(_deudaDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetDeuda(int id)
        {
            var deuda = _deudaDao.Buscar(id);

            if (deuda == null)
                return NotFound();

            return Ok(deuda);
        }

        [HttpPost("saveDeuda")]
        public ActionResult SaveDeuda(Deuda deuda)
        {
            _deudaDao.Registrar(deuda);
            return Created("", deuda);
        }

        [HttpPut("updateDeuda")]
        public ActionResult UpdateDeuda(Deuda deuda)
        {
            _deudaDao.Actualizar(deuda);
            return Ok(deuda);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDeuda(int id)
        {
            _deudaDao.Eliminar(id);
            return Ok();
        }
    }
}
