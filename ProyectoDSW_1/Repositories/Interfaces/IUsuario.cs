using ProyectoDSW_1.Models;

namespace ProyectoDSW_1.Repositories.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> Listar();
        Usuario? Buscar(int id);
        void Registrar(Usuario usuario);
        void Actualizar(Usuario usuario);
        void Eliminar(int id);
        Usuario? ObtenerPorUsuario(string usuario);
    }
}
