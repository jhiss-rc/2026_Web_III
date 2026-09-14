using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class PropietariosModel : PageModel
    {
        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaPropietarios = BaseDatos.Propietarios;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaPropietarios = BaseDatos.Propietarios;
                return Page();
            }

            Propietario.Id = BaseDatos.Propietarios.Count + 1;
            BaseDatos.Propietarios.Add(Propietario);

            return RedirectToPage("/Propietarios");
        }
    }
}
