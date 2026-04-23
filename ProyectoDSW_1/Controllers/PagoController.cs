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


        //voucher de pago
        [HttpGet("voucher-html/{id}")]
        public IActionResult VoucherHtml(int id)
        {
            var pago = _pagoDAO.ObtenerPorId(id);

            if (pago == null)
                return NotFound("Pago no encontrado");

            var html = $@"
    <html>
    <head>
        <meta charset='UTF-8'>
        <title>Voucher de Pago</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
                margin: 40px;
            }}
            .voucher {{
                border: 1px solid #ccc;
                padding: 20px;
                max-width: 500px;
            }}
            h1 {{
                text-align: center;
            }}
            p {{
                margin: 8px 0;
            }}
        </style>
    </head>
    <body>
        <div class='voucher'>
            <h1>Voucher de Pago</h1>
            <p><strong>ID Pago:</strong> {pago.Id}</p>
            <p><strong>DuenoId:</strong> {pago.Deuda?.Tienda?.DuenoId}</p>
            <p><strong>Nombre dueño:</strong> {pago.Deuda?.Tienda?.Dueno?.nombre}</p>
            <p><strong>Dueño:</strong> {pago.Deuda?.Tienda?.Dueno?.nombre} {pago.Deuda?.Tienda?.Dueno?.apellido}</p>
            <p><strong>RUC:</strong> {pago.Deuda?.Tienda?.Dueno?.ruc}</p>
            <p><strong>Fecha de Pago:</strong> {pago.FechaPago}</p>
            <p><strong>Monto Pagado:</strong> S/ {pago.MontoPago}</p>
            <p><strong>ID Deuda:</strong> {pago.DeudaId}</p>
            <p><strong>Estado:</strong> {pago.Deuda?.Estado}</p>
            <p><strong>Tienda ID:</strong> {pago.Deuda?.TiendaId}</p>
            <p><strong>Servicio:</strong> {pago.Deuda?.Servicio?.Nombre}</p>
            <p><strong>Fecha Facturación:</strong> {pago.Deuda?.FechaFacturacion}</p>
            <p><strong>Fecha Límite:</strong> {pago.Deuda?.FechaLimitePago}</p>
        </div>
    </body>
    </html>";

            return Content(html, "text/html");
        }



    }
}
