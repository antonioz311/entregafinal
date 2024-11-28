using GestionInventario.Models;
using GestionInventario.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Services
{
    public class InventarioServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public InventarioServicio(ProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Consulta el inventario con filtros opcionales por nombre y categoría.
        /// </summary>
        /// <param name="nombre">Nombre del producto (opcional).</param>
        /// <param name="categoria">Categoría del producto (opcional).</param>
        /// <returns>Lista de productos en inventario con detalles.</returns>
        public List<ProductoInventarioDto> ConsultarInventario(string? nombre = null, string? categoria = null)
        {
            var productos = _productoRepositorio.ObtenerTodos();

            // Filtrar por nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                productos = productos
                    .Where(p => p.Nombre.Contains(nombre, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filtrar por categoría
            if (!string.IsNullOrEmpty(categoria))
            {
                productos = productos
                    .Where(p => p.Categoria.Contains(categoria, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Mapear a DTO
            return productos.Select(p => new ProductoInventarioDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                PrecioUnitario = p.Precio,
                CantidadDisponible = p.Cantidad
            }).ToList();
        }

        /// <summary>
        /// Obtiene el inventario completo sin filtros.
        /// </summary>
        /// <returns>Lista completa de productos en inventario.</returns>
        public List<ProductoInventarioDto> ObtenerInventarioCompleto()
        {
            return ConsultarInventario();
        }
    }

    /// <summary>
    /// DTO para detalles de inventario de productos.
    /// </summary>
    public class ProductoInventarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
