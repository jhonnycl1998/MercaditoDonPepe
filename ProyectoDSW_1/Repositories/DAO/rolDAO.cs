using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class rolDAO : IRol
    {
        private readonly APPDbContext _context;
        public rolDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rol> Listar()
        {
            return _context.Roles.ToList();
        }

        public Rol? Buscar(int id)
        {
            return _context.Roles.Find(id);
        }

        public void Registrar(Rol rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
        }

        public void Actualizar(Rol rol)
        {
            _context.Roles.Update(rol);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var rol = _context.Roles.Find(id);

            if (rol != null)
            {
                _context.Roles.Remove(rol);
                _context.SaveChanges();
            }
        }
    }
}
