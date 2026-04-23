using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IDeuda
    {
        IEnumerable<Deuda> Listar();
        Deuda? Buscar(int id);
        void Registrar(Deuda deuda);
        void Actualizar(Deuda deuda);
        void Eliminar(int id);
        bool ExisteDeuda(int tiendaId, int servicioId, DateTime fechaFacturacion);
    }
}
