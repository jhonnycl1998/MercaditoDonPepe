using Microsoft.EntityFrameworkCore;
using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class pagoDAO : IPago
    {
        private readonly APPDbContext _context;

        public pagoDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pago> Listar()
        {
            return _context.Pagos
                .Include(p => p.Deuda)
                .ToList();
        }

        public Pago? ObtenerPorId(int id)
        {
            return _context.Pagos
                .Include(p => p.Deuda)
                .FirstOrDefault(p => p.Id == id);
        }

        public Pago? ObtenerPorDeudaId(int deudaId)
        {
            return _context.Pagos
                .Include(p => p.Deuda)
                .FirstOrDefault(p => p.DeudaId == deudaId);
        }

        public Pago RegistrarPago(Pago pago)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var deuda = _context.Deudas.FirstOrDefault(d => d.Id == pago.DeudaId);

                if (deuda == null)
                    throw new Exception("La deuda no existe.");

                if (deuda.Estado.ToLower() == "pagado")
                    throw new Exception("La deuda ya fue pagada.");

                var pagoExistente = _context.Pagos.FirstOrDefault(p => p.DeudaId == pago.DeudaId);

                if (pagoExistente != null)
                    throw new Exception("Ya existe un pago registrado para esta deuda.");

                if (pago.MontoPago <= 0)
                    throw new Exception("El monto de pago debe ser mayor a 0.");

                if (pago.MontoPago != deuda.MontoDeuda)
                    throw new Exception("El monto del pago debe ser igual al monto total de la deuda.");

                pago.FechaPago = DateTime.Now;

                _context.Pagos.Add(pago);

                deuda.Estado = "Pagado";
                _context.Deudas.Update(deuda);

                _context.SaveChanges();
                transaction.Commit();

                return pago;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Eliminar(int id)
        {
            var pago = _context.Pagos.FirstOrDefault(p => p.Id == id);

            if (pago == null)
                return false;

            _context.Pagos.Remove(pago);
            _context.SaveChanges();

            return true;
        }
    }
}
