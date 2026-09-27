using bibliotecaUnivalle.Filters;
using bibliotecaUnivalle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bibliotecaUnivalle.Controllers
{
    [VerificarSesion]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("UsuarioRol");

            return rol switch
            {
                "Administrador" => View("IndexAdministrador"),
                "Bibliotecario" => View("IndexBibliotecario"),
                _ => View("IndexUsuario")
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
