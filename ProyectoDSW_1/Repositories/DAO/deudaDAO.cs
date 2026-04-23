using Microsoft.EntityFrameworkCore;
using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class deudaDAO : IDeuda
    {
        private readonly APPDbContext _context;

        public deudaDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Deuda> Listar()
        {
            return _context.Deudas.ToList();
        }

        public Deuda? Buscar(int id)
        {
            return _context.Deudas.Find(id);
        }

        public void Registrar(Deuda deuda)
        {
            _context.Deudas.Add(deuda);
            _context.SaveChanges();
        }

        public void Actualizar(Deuda deuda)
        {
            _context.Deudas.Update(deuda);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var deuda = _context.Deudas.Find(id);

            if (deuda != null)
            {
                _context.Deudas.Remove(deuda);
                _context.SaveChanges();
            }
        }
        public bool ExisteDeuda(int tiendaId, int servicioId, DateTime fechaFacturacion)
        {
            return _context.Deudas.Any(d =>
                d.TiendaId == tiendaId &&
                d.ServicioId == servicioId &&
                d.FechaFacturacion.Month == fechaFacturacion.Month &&
                d.FechaFacturacion.Year == fechaFacturacion.Year);
        }

        public IEnumerable<Deuda> ObtenerPendientesPorDueno(int duenoId)
        {
            return _context.Deudas
                .Include(d => d.Tienda)
                .Include(d => d.Servicio)
                .Where(d => d.Estado == "Pendiente" && d.Tienda.DuenoId == duenoId)
                .ToList();
        }


    }
}
