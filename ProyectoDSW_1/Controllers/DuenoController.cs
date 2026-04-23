using Microsoft.AspNetCore.Mvc;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuenoController : Controller
    {
        private readonly IDueno _duenoDao;

        public DuenoController(IDueno duenoDao)
        {
            _duenoDao = duenoDao;
        }

        [HttpGet("getDuenos")]
        public ActionResult GetDuenos()
        {
            return Ok(_duenoDao.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult GetDueno(int id)
        {
            var dueno = _duenoDao.Buscar(id);

            if (dueno == null)
                return NotFound();

            return Ok(dueno);
        }

        [HttpPost("saveDueno")]
        public ActionResult SaveDueno(Dueno dueno)
        {
            _duenoDao.Registrar(dueno);
            return Created("", dueno);
        }

        [HttpPut("updateDueno")]
        public ActionResult UpdateDueno(Dueno dueno)
        {
            _duenoDao.Actualizar(dueno);
            return Ok(dueno);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDueno(int id)
        {
            _duenoDao.Eliminar(id);
            return Ok();
        }
    }
}
