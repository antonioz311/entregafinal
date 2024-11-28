using Microsoft.AspNetCore.Mvc;
using GestionInventario.Models;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServicio _usuarioServicio;

        public UsuarioController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("crear")]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            _usuarioServicio.CrearUsuario(usuario);
            return Ok("Usuario creado exitosamente.");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var valido = _usuarioServicio.ValidarUsuario(email, password);
            if (valido)
                return Ok("Inicio de sesión exitoso.");
            return Unauthorized("Credenciales incorrectas.");
        }

        [HttpGet("obtener/{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = _usuarioServicio.ObtenerUsuarioPorId(id);
            if (usuario != null)
                return Ok(usuario);
            return NotFound("Usuario no encontrado.");
        }
    }
}
