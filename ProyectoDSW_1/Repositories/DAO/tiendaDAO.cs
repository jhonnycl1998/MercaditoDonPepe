using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class tiendaDAO : ITienda
    {
        private readonly APPDbContext _context;

        public tiendaDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tienda> Listar()
        {
            return _context.Tiendas.ToList();
        }

        public Tienda? Buscar(int id)
        {
            return _context.Tiendas.Find(id);
        }

        public void Registrar(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            _context.SaveChanges();
        }

        public void Actualizar(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tienda = _context.Tiendas.Find(id);

            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                _context.SaveChanges();
            }
        }
    }
}
