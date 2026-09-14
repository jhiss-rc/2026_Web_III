using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class MascotasModel : PageModel
    {
        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaMascotas = BaseDatos.Mascotas;
            ListaPropietarios = BaseDatos.Propietarios;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaMascotas = BaseDatos.Mascotas;
                ListaPropietarios = BaseDatos.Propietarios;
                return Page();
            }

            Mascota.Id = BaseDatos.Mascotas.Count + 1;
            BaseDatos.Mascotas.Add(Mascota);

            return RedirectToPage("/Mascotas");
        }
    }
}
