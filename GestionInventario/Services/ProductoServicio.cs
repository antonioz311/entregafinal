using GestionInventario.Repositories;
using GestionInventario.Models;

namespace GestionInventario.Services
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public ProductoServicio(ProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public void CrearProducto(Producto producto)
        {
            _productoRepositorio.CrearProducto(producto);
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return _productoRepositorio.ObtenerProductoPorId(id);
        }

        public void ActualizarProducto(Producto producto)
        {
            _productoRepositorio.ActualizarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            _productoRepositorio.EliminarProducto(id);
        }
    }
}
