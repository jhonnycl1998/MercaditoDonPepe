using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IRol
    {
        IEnumerable<Rol> Listar();
        Rol? Buscar(int id);
        void Registrar(Rol rol);
        void Actualizar(Rol rol);
        void Eliminar(int id);
    }
}
