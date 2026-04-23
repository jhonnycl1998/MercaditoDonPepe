using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : Controller
    {
        private readonly IPago _pagoDAO;

        public PagoController(IPago pagoDAO)
        {
            _pagoDAO = pagoDAO;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _pagoDAO.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var pago = _pagoDAO.ObtenerPorId(id);

            if (pago == null)
                return NotFound(new { mensaje = "Pago no encontrado" });

            return Ok(pago);
        }

        [HttpGet("deuda/{deudaId}")]
        public IActionResult ObtenerPorDeudaId(int deudaId)
        {
            var pago = _pagoDAO.ObtenerPorDeudaId(deudaId);

            if (pago == null)
                return NotFound(new { mensaje = "No existe pago para esa deuda" });

            return Ok(pago);
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Pago pago)
        {
            try
            {
                var nuevoPago = _pagoDAO.RegistrarPago(pago);
                return Ok(new
                {
                    mensaje = "Pago registrado correctamente",
                    pago = nuevoPago
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminado = _pagoDAO.Eliminar(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Pago no encontrado" });

            return Ok(new { mensaje = "Pago eliminado correctamente" });
        }

    }
}
