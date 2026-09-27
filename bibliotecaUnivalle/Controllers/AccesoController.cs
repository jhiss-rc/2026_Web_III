using bibliotecaUnivalle.Data;
using bibliotecaUnivalle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaUnivalle.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDbContext _context;

        public AccesoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Acceso/Login
        public IActionResult Login()
        {
            // Si ya hay sesión activa, redirige al Home
            if (HttpContext.Session.GetString("UsuarioEmail") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Acceso/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Buscar usuario por email y contraseña
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == model.Email
                                       && u.Contrasena == model.Contrasena
                                       && u.Estado == true);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return View(model);
            }

            // Guardar datos en sesión
            HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
            HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
            HttpContext.Session.SetString("UsuarioRol", usuario.Rol);
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

            return RedirectToAction("Index", "Home");
        }

        // GET: Acceso/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Acceso");
        }

        // GET: Acceso/AccesoDenegado
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
