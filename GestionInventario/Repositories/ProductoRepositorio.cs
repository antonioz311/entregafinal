using GestionInventario.Models;
using GestionInventario.Data;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class ProductoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerTodos()
        {
            return _context.Productos.ToList();
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return _context.Productos.Find(id);
        }

        public void CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void EliminarProducto(int id)
        {
            var producto = ObtenerProductoPorId(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}
