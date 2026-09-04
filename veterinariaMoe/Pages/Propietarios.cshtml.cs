using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class PropietariosModel : PageModel
    {
        [BindProperty]
        public string Nombre { get; set; } = "";

        [BindProperty]
        public string Apellidos { get; set; } = "";

        [BindProperty]
        public string Telefono { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public bool Estado { get; set; } = true;

        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaPropietarios = BaseDatos.Propietarios;
        }

        public IActionResult OnPost()
        {
            var nuevo = new Propietario
            {
                Id        = BaseDatos.Propietarios.Count + 1,
                Nombre    = Nombre,
                Apellidos = Apellidos,
                Telefono  = Telefono,
                Email     = Email,
                Estado    = Estado
            };

            BaseDatos.Propietarios.Add(nuevo);

            return RedirectToPage("/Propietarios");
        }
    }
}
