using Microsoft.EntityFrameworkCore;
using ProyectoDSW_1.Data;
using ProyectoDSW_1.Models;
using ProyectoDSW_1.Repositories.Interfaces;

namespace ProyectoDSW_1.Repositories.DAO
{
    public class usuarioDAO : IUsuario
    {
        private readonly APPDbContext _context;

        public usuarioDAO(APPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> Listar()
        {
            return _context.Usuarios
                .Include(u=>u.Rol)
                .ToList();
        }

        public Usuario? Buscar(int id)
        {
            return _context.Usuarios
                .Include (u=>u.Rol)
                .FirstOrDefault(u => u.id == id);
        }

        public void Registrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public Usuario? ObtenerPorUsuario(string usuario)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.usuario == usuario);
        }
    }
}
