using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenciaController : ControllerBase
    {
        private readonly EviService _eviService;

        public EvidenciaController(EviService eviService)
        {
            _eviService = eviService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var evidencias = _eviService.ObtenerTodo();
            return Ok(evidencias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evidencia = _eviService.ObtenerPorId(id);

            if (evidencia == null)
                return NotFound();

            return Ok(evidencia);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Evidencia nueva)
        {
            if (nueva == null)
                return BadRequest();

            _eviService.Insertar(nueva);
            return Ok(nueva);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Evidencia modificada)
        {
            if (modificada == null)
                return BadRequest();

            var existente = _eviService.ObtenerPorId(modificada.Evi_Id);

            if (existente == null)
                return NotFound();

            _eviService.Actualizar(modificada);
            return Ok(modificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _eviService.ObtenerPorId(id);

            if (existente == null)
                return NotFound();

            _eviService.Borrar(id);
            return Ok();
        }
    }

}