using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class servicioDAO : IServicio
    {
        private readonly APPDbContext _context;

        public servicioDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servicio> Listar()
        {
            return _context.Servicios.ToList();
        }

        public Servicio? Buscar(int id)
        {
            return _context.Servicios.Find(id);
        }

        public void Registrar(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            _context.SaveChanges();
        }

        public void Actualizar(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var servicio = _context.Servicios.Find(id);

            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                _context.SaveChanges();
            }
        }
    }
}
