using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _service;

        public ReporteController(IReporteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ObternerTodo()
        {
            var reportes = _service.ObtenerTodo();
            return Ok(reportes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reporte = _service.ObtenerPorId(id);

            if (reporte == null)
                return NotFound();

            return Ok(reporte);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Reporte nuevo)
        {
            if (nuevo == null)
                return BadRequest();

            _service.Insertar(nuevo);
            return Ok(nuevo);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Reporte modificado)
        {
            if (modificado == null)
                return BadRequest();

            var existente = _service.ObtenerPorId(modificado.Rep_Id);

            if (existente == null)
                return NotFound();

            _service.Actualizar(modificado);
            return Ok(modificado);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            var existente = _service.ObtenerPorId(id);

            if (existente == null)
                return NotFound();

            _service.Borrar(id);
            return Ok();
        }
    }
}