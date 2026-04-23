using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IDueno
    {
        IEnumerable<Dueno> Listar();
        Dueno? Buscar(int id);
        void Registrar(Dueno dueño);
        void Actualizar(Dueno dueño);
        void Eliminar(int id);
    }
}
