using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly ReporteServicio _reporteServicio;

        public ReporteController(ReporteServicio reporteServicio)
        {
            _reporteServicio = reporteServicio;
        }

        [HttpGet("exportar")]
        public IActionResult ExportarInventario(bool todosProductos = true, int? productoId = null)
        {
            var csv = _reporteServicio.GenerarReporteInventario(todosProductos, productoId);
            return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", "inventario.csv");
        }
    }
}
