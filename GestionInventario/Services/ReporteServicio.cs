using GestionInventario.Models;
using GestionInventario.Repositories;
using System.Linq;
using System.Text;

namespace GestionInventario.Services
{
    public class ReporteServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly MovimientoRepositorio _movimientoRepositorio;

        public ReporteServicio(ProductoRepositorio productoRepositorio, MovimientoRepositorio movimientoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _movimientoRepositorio = movimientoRepositorio;
        }

        public string GenerarReporteInventario(bool todosProductos, int? productoId = null)
        {
            var productos = todosProductos
                ? _productoRepositorio.ObtenerTodos()
                : _productoRepositorio.ObtenerTodos().Where(p => p.Id == productoId);

            var sb = new StringBuilder();
            sb.AppendLine("Producto, Cantidad, Precio, Categoría");

            foreach (var producto in productos)
            {
                sb.AppendLine($"{producto.Nombre}, {producto.Cantidad}, {producto.Precio}, {producto.Categoria}");
            }

            return sb.ToString();
        }
    }
}
