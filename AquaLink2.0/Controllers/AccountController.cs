using AquaLink2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaLink2._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly AutenService _autenService;

        public AccountController(AutenService autenService)
        {
            _autenService = autenService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string password)
        {
            var usuario = await _autenService.LoginAsync(correo, password);
            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }
    }
}
