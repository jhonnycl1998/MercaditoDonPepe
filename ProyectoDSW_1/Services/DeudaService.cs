using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Services
{
    public class DeudaService
    {
        private readonly ITienda _tiendaDao;
        private readonly IServicio _servicioDao;
        private readonly IDeuda _deudaDao;

        public DeudaService(ITienda tiendaDao, IServicio servicioDao, IDeuda deudaDao)
        {
            _tiendaDao = tiendaDao;
            _servicioDao = servicioDao;
            _deudaDao = deudaDao;
        }

        public void GenerarDeudasAutomaticas()
        {

            DateTime fechaActual = DateTime.Now;
            int diaActual = fechaActual.Day;


            var serviciosDelDia = _servicioDao.Listar()
               .Where(s => s.DiaCorte == diaActual)
               .ToList();


            var tiendas = _tiendaDao.Listar().ToList();


            foreach (var servicio in serviciosDelDia)
            {

                foreach (var tienda in tiendas)
                {

                    bool existe = _deudaDao.ExisteDeuda(tienda.Id, servicio.Id, fechaActual);
                    if (!existe)
                    {
                        Deuda nuevaDeuda = new Deuda
                        {
                            MontoDeuda = servicio.Costo,
                            FechaFacturacion = DateTime.Now,
                            FechaLimitePago = DateTime.Now.AddDays(5),
                            Estado = "Pendiente",
                            TiendaId = tienda.Id,
                            ServicioId = servicio.Id
                        };

                        _deudaDao.Registrar(nuevaDeuda);


                    }
                }
            }

        }
    }
}
