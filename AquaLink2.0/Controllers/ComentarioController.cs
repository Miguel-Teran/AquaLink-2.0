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

        [HttpPost]
        public async Task<IActionResult> Agregar(Comentario nuevo)
        {
            if (nuevo != null && !string.IsNullOrEmpty(nuevo.Com_Descripcion))
            {
                // CAMBIO: De AgregarComentarioAsync a Insertar
                await _comentarioService.Insertar(nuevo);
                return RedirectToAction("Index", "Reporte");
            }
            return BadRequest("El comentario no puede estar vacío.");
        }
    }
}
