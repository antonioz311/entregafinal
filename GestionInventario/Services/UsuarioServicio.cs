using GestionInventario.Models;
using System.Collections.Generic;

namespace GestionInventario.Services
{
    public class UsuarioServicio
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        /// <summary>
        /// Crea un nuevo usuario con el rol especificado.
        /// </summary>
        /// <param name="usuario">Instancia del usuario a crear.</param>
        public void CrearUsuario(Usuario usuario)
        {
            if (usuario.Rol != "Administrador" && usuario.Rol != "Auxiliar")
            {
                throw new ArgumentException("El rol debe ser 'Administrador' o 'Auxiliar'.");
            }

            _usuarios.Add(usuario);
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="email">Email del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Verdadero si las credenciales son válidas; falso en caso contrario.</returns>
        public bool ValidarUsuario(string email, string password)
        {
            return _usuarios.Exists(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Usuario encontrado o null si no existe.</returns>
        public Usuario? ObtenerUsuarioPorId(int id)
        {
            return _usuarios.Find(u => u.Id == id);
        }

        /// <summary>
        /// Verifica si un usuario tiene el rol de administrador.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Verdadero si es administrador; falso en caso contrario.</returns>
        public bool EsAdministrador(int usuarioId)
        {
            var usuario = ObtenerUsuarioPorId(usuarioId);
            return usuario?.EsAdministrador ?? false;
        }
    }
}
