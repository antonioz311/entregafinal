using GestionInventario.Data;
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class UsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        
        /// Obtiene un usuario por su email.
       
        public Usuario? ObtenerUsuarioPorEmail(string email)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Email == email);
        }

        /// Obtiene un usuario por su ID.
        
        public Usuario? ObtenerUsuarioPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
        
        /// Verifica si un usuario tiene un rol específico.
       
        public bool UsuarioTieneRol(int id, string rol)
        {
            var usuario = ObtenerUsuarioPorId(id);
            return usuario != null && usuario.Rol.Equals(rol, System.StringComparison.OrdinalIgnoreCase);
        }

        
        /// Obtiene todos los usuarios con un rol específico.

        public List<Usuario> ObtenerUsuariosPorRol(string rol)
        {
            return _context.Usuarios
                .Where(u => u.Rol.Equals(rol, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

     
        //Agrega un nuevo usuario al contexto.
       
        public void CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
