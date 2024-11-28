using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;
using GestionInventario.Models;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorServicio _proveedorServicio;

        public ProveedorController(ProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        [HttpPost]
        public IActionResult CrearProveedor([FromBody] Proveedor proveedor)
        {
            _proveedorServicio.CrearProveedor(proveedor);
            return Ok(new { Message = "Proveedor creado exitosamente." });
        }

        [HttpGet]
        public IActionResult ObtenerProveedores()
        {
            var proveedores = _proveedorServicio.ObtenerProveedores();
            return Ok(proveedores);
        }

        [HttpPut]
        public IActionResult ActualizarProveedor([FromBody] Proveedor proveedor)
        {
            _proveedorServicio.ActualizarProveedor(proveedor);
            return Ok(new { Message = "Proveedor actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProveedor(int id)
        {
            _proveedorServicio.EliminarProveedor(id);
            return Ok(new { Message = "Proveedor eliminado correctamente." });
        }
    }
}
