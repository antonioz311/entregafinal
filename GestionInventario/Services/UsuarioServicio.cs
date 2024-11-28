using GestionInventario.Models;
using System.Collections.Generic;

namespace GestionInventario.Services
{
    public class UsuarioServicio
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

      
        /// Crea un nuevo usuario con el rol especificado.
        public void CrearUsuario(Usuario usuario)
        {
            if (usuario.Rol != "Administrador" && usuario.Rol != "Auxiliar")
            {
                throw new ArgumentException("El rol debe ser 'Administrador' o 'Auxiliar'.");
            }

            _usuarios.Add(usuario);
        }

        /// Valida las credenciales de un usuario
        public bool ValidarUsuario(string email, string password)
        {
            return _usuarios.Exists(u => u.Email == email && u.Password == password);
        }

      
        /// Obtiene un usuario por su ID.

        public Usuario? ObtenerUsuarioPorId(int id)
        {
            return _usuarios.Find(u => u.Id == id);
        }

        /// Verifica si un usuario tiene el rol de administrador.

        public bool EsAdministrador(int usuarioId)
        {
            var usuario = ObtenerUsuarioPorId(usuarioId);
            return usuario?.EsAdministrador ?? false;
        }
    }
}
