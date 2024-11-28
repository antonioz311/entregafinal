using Microsoft.AspNetCore.Mvc;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly UsuarioServicio _usuarioServicio;

        public AutenticarController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (_usuarioServicio.ValidarUsuario(request.Email, request.Password))
            {
                return Ok(new { Message = "Login exitoso" });
            }

            return Unauthorized(new { Message = "Credenciales inválidas" });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

