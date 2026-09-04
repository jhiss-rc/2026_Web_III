using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class MascotasModel : PageModel
    {
        [BindProperty]
        public int PropietarioId { get; set; }

        [BindProperty]
        public string Nombre { get; set; } = "";

        [BindProperty]
        public string Especie { get; set; } = "";

        [BindProperty]
        public string Raza { get; set; } = "";

        [BindProperty]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;

        [BindProperty]
        public bool Estado { get; set; } = true;

        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaMascotas = BaseDatos.Mascotas;
            ListaPropietarios = BaseDatos.Propietarios;
        }

        public IActionResult OnPost()
        {
            var nueva = new Mascota
            {
                Id              = BaseDatos.Mascotas.Count + 1,
                PropietarioId   = PropietarioId,
                Nombre          = Nombre,
                Especie         = Especie,
                Raza            = Raza,
                FechaNacimiento = FechaNacimiento,
                Estado          = Estado
            };

            BaseDatos.Mascotas.Add(nueva);

            return RedirectToPage("/Mascotas");
        }
    }
}
