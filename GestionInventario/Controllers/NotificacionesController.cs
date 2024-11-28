using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly NotificacionServicio _notificacionServicio;

        public NotificacionesController(NotificacionServicio notificacionServicio)
        {
            _notificacionServicio = notificacionServicio;
        }

        [HttpGet("alertas")]
        public IActionResult GenerarAlertas([FromQuery] int nivelMinimo)
        {
            var alertas = _notificacionServicio.GenerarAlertas(nivelMinimo);
            return Ok(alertas);
        }
    }
}
