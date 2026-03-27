using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace AquaLink2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult ObtenerTodo()
        {
            var usuarios = _usuarioService.ObtenerTodo();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuario nuevo)
        {
            if (nuevo == null) return BadRequest("Los datos del usuario son nulos.");

            // Esto valida las [Annotations] que pusimos en el modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _usuarioService.Insertar(nuevo);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Usu_Id }, nuevo);
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
        public IActionResult Login([FromBody] Login request)
        {
            // Si llegamos aquí, es que .NET pudo leer el JSON correctamente
            if (request == null || string.IsNullOrEmpty(request.Usu_Correo))
            {
                return BadRequest(new { message = "Datos de inicio de sesión incompletos" });
            }

            // Llamamos a tu servicio con los datos del objeto 'request'
            var usuario = _usuarioService.ValidarLogin(request.Usu_Correo, request.Usu_Password);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrecta" });
            }

            return Ok(usuario);
        }
    }
}