using Microsoft.EntityFrameworkCore;
using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class duenoDAO : IDueno
    {
        private readonly APPDbContext _context;

        public duenoDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dueno> Listar()
        {
            return _context.Duenos
                .Include(d => d.Tiendas)
                .ToList();
        }

        public Dueno? Buscar(int id)
        {
            return _context.Duenos
                .Include(d => d.Tiendas)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Registrar(Dueno dueno)
        {
            _context.Duenos.Add(dueno);
            _context.SaveChanges();
        }

        public void Actualizar(Dueno dueno)
        {
            _context.Duenos.Update(dueno);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var dueno = _context.Duenos.Find(id);

            if (dueno != null)
            {
                _context.Duenos.Remove(dueno);
                _context.SaveChanges();
            }
        }
    }
}
