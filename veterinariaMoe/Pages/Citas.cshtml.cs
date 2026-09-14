using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class CitasModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public CitasModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public List<Cita> ListaCitas { get; set; } = new();
        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaCitas = _context.Citas.ToList();
            ListaMascotas = _context.Mascotas.ToList();
            ListaPropietarios = _context.Propietarios.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaCitas = _context.Citas.ToList();
                ListaMascotas = _context.Mascotas.ToList();
                return Page();
            }

            _context.Citas.Add(Cita);
            _context.SaveChanges();

            return RedirectToPage("/Citas");
        }
    }
}
