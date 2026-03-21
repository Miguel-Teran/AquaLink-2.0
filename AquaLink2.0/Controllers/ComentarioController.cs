using AquaLink2._0.Models;
using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly ComentarioService _comentarioService;

        public ComentarioController(ComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }
        public async Task<IActionResult> VerPorReporte(int idReporte)
        {
            var comentarios = await _comentarioService.ObtenerPorReporteAsync(idReporte);
            return View(comentarios);
        }
        public IActionResult Crear(int idReporte)
        {
            var comentario = new Comentario
            {
                Com_IdRep = idReporte
            };

            return View(comentario);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Comentario nuevo)
        {
            if (!ModelState.IsValid)
                return View(nuevo);

            var resultado = await _comentarioService.AgregarComentarioAsync(nuevo);

            if (!resultado)
            {
<<<<<<< HEAD
                // CAMBIO: De AgregarComentarioAsync a Insertar
                await _comentarioService.Insertar(nuevo);
                return RedirectToAction("Index", "Reporte");
=======
                ViewBag.Error = "No se pudo agregar el comentario";
                return View(nuevo);
>>>>>>> b5ded573e8b681ebd88cc82e63e5b5ca2db6726d
            }

            return RedirectToAction("VerPorReporte", new { idReporte = nuevo.Com_IdRep });
        }
    }

}