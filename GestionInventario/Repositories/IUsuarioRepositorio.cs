using GestionInventario.Models;
using System.Threading.Tasks;

namespace GestionInventario.Repositories
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<Usuario> ObtenerPorEmailAsync(string email);
        Task CrearAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);
    }
}
