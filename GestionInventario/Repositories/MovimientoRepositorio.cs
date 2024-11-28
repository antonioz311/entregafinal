using GestionInventario.Data;
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class MovimientoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public MovimientoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CrearMovimiento(Movimiento movimiento)
        {
            _context.Movimientos.Add(movimiento);
            _context.SaveChanges();
        }

        public List<Movimiento> ObtenerMovimientos()
        {
            return _context.Movimientos.ToList();
        }

        public List<Movimiento> ObtenerMovimientosPorProducto(int productoId)
        {
            return _context.Movimientos.Where(m => m.ProductoId == productoId).ToList();
        }

        public List<int> ProductosConStockBajo(int nivelMinimo)
        {
            return _context.Productos
                .Where(p => p.Cantidad < nivelMinimo)
                .Select(p => p.Id)
                .ToList();
        }
    }
}
