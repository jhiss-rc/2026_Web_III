using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class CitasModel : PageModel
    {
        [BindProperty]
        public Cita Cita { get; set; } = new();

        public List<Cita> ListaCitas { get; set; } = new();
        public List<Mascota> ListaMascotas { get; set; } = new();

        public void OnGet()
        {
            ListaCitas = BaseDatos.Citas;
            ListaMascotas = BaseDatos.Mascotas;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaCitas = BaseDatos.Citas;
                ListaMascotas = BaseDatos.Mascotas;
                return Page();
            }

            Cita.Id = BaseDatos.Citas.Count + 1;
            BaseDatos.Citas.Add(Cita);

            return RedirectToPage("/Citas");
        }
    }
}
