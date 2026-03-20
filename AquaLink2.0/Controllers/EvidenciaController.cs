using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    public class EvidenciaController : Controller
    {
        private readonly EviService _evidenciaService;
        public EvidenciaController(EviService evidenciaService)
        {
            _evidenciaService = evidenciaService;
        }
        public async Task<IActionResult> VerPorReporte(int idReporte)
        {
            var evidencias = await _evidenciaService.ObtenerPorReporteAsync(idReporte);
            return View(evidencias);
        }
        public IActionResult Subir(int idReporte)
        {
            var evidencia = new Evidencia
            {
                Evi_IdRep = idReporte
            };

            return View(evidencia);
        }

        [HttpPost]
        public async Task<IActionResult> Subir(Evidencia nueva)
        {
            if (!ModelState.IsValid)
                return View(nueva);

            var resultado = await _evidenciaService.GuardarEvidenciaAsync(nueva);

            if (!resultado)
            {
                ViewBag.Error = "No se pudo guardar la evidencia";
                return View(nueva);
            }

            return RedirectToAction("VerPorReporte", new { idReporte = nueva.Evi_IdRep });
        }
    }

}