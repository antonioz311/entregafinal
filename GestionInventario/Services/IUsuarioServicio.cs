using GestionInventario.Models;
using System.Threading.Tasks;

namespace GestionInventario.Services
{
    public interface IUsuarioServicio
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<Usuario> ObtenerPorEmailAsync(string email);
        Task CrearUsuarioAsync(Usuario usuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(int id);
    }
}
