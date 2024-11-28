using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;
using GestionInventario.Models;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;

        public ProductoController(ProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto)
        {
            _productoServicio.CrearProducto(producto);
            return Ok(new { Message = "Producto creado exitosamente." });
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerProducto(int id)
        {
            var producto = _productoServicio.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound(new { Message = "Producto no encontrado." });
            }
            return Ok(producto);
        }

        [HttpPut]
        public IActionResult ActualizarProducto([FromBody] Producto producto)
        {
            _productoServicio.ActualizarProducto(producto);
            return Ok(new { Message = "Producto actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            _productoServicio.EliminarProducto(id);
            return Ok(new { Message = "Producto eliminado correctamente." });
        }
    }
}

