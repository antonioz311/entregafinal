using GestionInventario.Repositories;
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Services
{
    public class NotificacionServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public NotificacionServicio(ProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public List<string> GenerarAlertas(int nivelMinimo)
        {
            var productos = _productoRepositorio.ObtenerTodos()
                .Where(p => p.Cantidad < nivelMinimo)
                .Select(p => $"Producto: {p.Nombre}, Stock: {p.Cantidad}")
                .ToList();

            return productos;
        }

        public void RealizarPedidoAutomatico(int productoId, int cantidad)
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(productoId);
            if (producto != null)
            {
                // Crear pedido (simulación)
                producto.Cantidad += cantidad;
                _productoRepositorio.ActualizarProducto(producto);
            }
        }
    }
}
