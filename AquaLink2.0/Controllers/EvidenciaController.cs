using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    public class EvidenciaController : Controller
    {
        private readonly EviService _eviService;

        public EvidenciaController(EviService eviService)
        {
            _eviService = eviService;
        }

        public async Task<IActionResult> VerEvidencias(int idReporte)
        {
            var lista = await _eviService.ObtenerPorReporteAsync(idReporte);
            return View(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Subir(Evidencia nueva)
        {
            await _eviService.GuardarEvidenciaAsync(nueva);
            return RedirectToAction("Index", "Reporte");
        }
    }
}
