using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioService.ObtenerTodo();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuario nuevo)
        {
            if (nuevo == null)
                return BadRequest();

            _usuarioService.Insertar(nuevo);
            return Ok(nuevo);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario modificado)
        {
            if (modificado == null)
                return BadRequest();

            var existente = _usuarioService.ObtenerPorId(modificado.Usu_Id);

            if (existente == null)
                return NotFound();

            _usuarioService.Actualizar(modificado);
            return Ok(modificado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _usuarioService.ObtenerPorId(id);

            if (existente == null)
                return NotFound();

            _usuarioService.Borrar(id);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            if (login == null)
                return BadRequest();

            var usuario = _usuarioService.ValidarLogin(login.Correo, login.Password);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            return Ok(usuario);
        }
    }

    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}