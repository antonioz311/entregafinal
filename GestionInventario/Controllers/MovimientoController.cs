using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly MovimientoServicio _movimientoServicio;

        public MovimientoController(MovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
        }

        [HttpPost("entrada")]
        public IActionResult AdicionarExistencias(int productoId, int cantidad, string motivo)
        {
            try
            {
                _movimientoServicio.AdicionarExistencias(productoId, cantidad, motivo);
                return Ok(new { Message = "Existencias añadidas correctamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("salida")]
        public IActionResult DisminuirExistencias(int productoId, int cantidad, string motivo)
        {
            try
            {
                _movimientoServicio.DisminuirExistencias(productoId, cantidad, motivo);
                return Ok(new { Message = "Existencias disminuidas correctamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObtenerMovimientos()
        {
            var movimientos = _movimientoServicio.ObtenerMovimientos();
            return Ok(movimientos);
        }
    }
}
