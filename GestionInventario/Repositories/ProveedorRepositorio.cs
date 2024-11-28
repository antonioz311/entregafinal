using GestionInventario.Data;
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class ProveedorRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
        }

        public Proveedor? ObtenerProveedorPorId(int id)
        {
            return _context.Proveedores.Find(id);
        }

        public List<Proveedor> ObtenerProveedores()
        {
            return _context.Proveedores.ToList();
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            _context.SaveChanges();
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _context.Proveedores.Find(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                _context.SaveChanges();
            }
        }
    }
}
