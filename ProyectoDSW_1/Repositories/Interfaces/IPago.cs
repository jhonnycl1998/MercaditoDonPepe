using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IPago
    {
        IEnumerable<Pago> Listar();
        Pago? ObtenerPorId(int id);
        Pago? ObtenerPorDeudaId(int deudaId);
        Pago RegistrarPago(Pago pago);
        bool Eliminar(int id);

    }
}
