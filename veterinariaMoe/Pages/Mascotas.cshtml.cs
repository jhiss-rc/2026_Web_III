using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class MascotasModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public MascotasModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaMascotas = _context.Mascotas.ToList();
            ListaPropietarios = _context.Propietarios.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaMascotas = _context.Mascotas.ToList();
                ListaPropietarios = _context.Propietarios.ToList();
                return Page();
            }

            _context.Mascotas.Add(Mascota);
            _context.SaveChanges();

            return RedirectToPage("/Mascotas");
        }
    }
}
