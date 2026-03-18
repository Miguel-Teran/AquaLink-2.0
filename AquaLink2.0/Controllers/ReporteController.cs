using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ReporteService _reporteService;

        public ReporteController(ReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _reporteService.ListarTodosAsync();

            return View(lista);
        }
    }
}
