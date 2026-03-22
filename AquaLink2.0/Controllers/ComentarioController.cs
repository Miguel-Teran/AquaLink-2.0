using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _comentarioService;

        public ComentarioController(ComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var comentarios = _comentarioService.ObtenerTodo();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comentario = _comentarioService.ObtenerPorId(id);

            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Comentario nuevo)
        {
            if (nuevo == null)
                return BadRequest();

            _comentarioService.Insertar(nuevo);
            return Ok(nuevo);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Comentario modificado)
        {
            if (modificado == null)
                return BadRequest();

            var existente = _comentarioService.ObtenerPorId(modificado.Com_Id);

            if (existente == null)
                return NotFound();

            _comentarioService.Actualizar(modificado);
            return Ok(modificado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _comentarioService.ObtenerPorId(id);

            if (existente == null)
                return NotFound();

            _comentarioService.Borrar(id);
            return Ok();
        }
    }
}