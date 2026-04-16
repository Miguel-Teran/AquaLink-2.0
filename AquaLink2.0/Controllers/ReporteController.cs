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
        public IActionResult Insertar([FromBody] Reporte reporte) // Cambié 'nuevo' por 'reporte' para ser estándar
        {
            if (reporte == null) return BadRequest("El objeto es nulo");

            // Si rep_Fecha es DateOnly, el string "YYYY-MM-DD" que mandamos arriba entrará perfecto.
            _service.Insertar(reporte);
            return Ok(reporte);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Reporte modificado)
        {
            // Si modificado.Rep_Id llega en 0, es por eso que da el 400
            if (modificado == null || modificado.Rep_Id == 0)
                return BadRequest("El ID del reporte es inválido.");

            _service.Actualizar(modificado);
            return Ok(new { message = "Actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            var reporte = _service.ObtenerPorId(id);

            if (reporte == null)
                return NotFound();
            try
            {
                _service.Borrar(id);
                return Ok(new { message = "Reporte eliminado exitosamente" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}