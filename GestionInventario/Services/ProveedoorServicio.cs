using GestionInventario.Models;
using GestionInventario.Repositories;

namespace GestionInventario.Services
{
    public class ProveedorServicio
    {
        private readonly ProveedorRepositorio _proveedorRepositorio;

        public ProveedorServicio(ProveedorRepositorio proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            _proveedorRepositorio.CrearProveedor(proveedor);
        }

        public Proveedor? ObtenerProveedorPorId(int id)
        {
            return _proveedorRepositorio.ObtenerProveedorPorId(id);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _proveedorRepositorio.ActualizarProveedor(proveedor);
        }

        public void EliminarProveedor(int id)
        {
            _proveedorRepositorio.EliminarProveedor(id);
        }

        public object ObtenerProveedores()
        {
            return _proveedorRepositorio.ObtenerProveedores();
        }
    }
}

