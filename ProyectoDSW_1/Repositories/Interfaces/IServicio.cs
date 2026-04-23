using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IServicio
    {
        IEnumerable<Servicio> Listar();
        Servicio? Buscar(int id);
        void Registrar(Servicio servicio);
        void Actualizar(Servicio servicio);
        void Eliminar(int id);
    }
}
