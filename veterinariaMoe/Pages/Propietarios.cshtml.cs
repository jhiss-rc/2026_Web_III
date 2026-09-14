using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class PropietariosModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public PropietariosModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public List<Propietario> ListaPropietarios { get; set; } = new();

        public void OnGet()
        {
            ListaPropietarios = _context.Propietarios.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaPropietarios = _context.Propietarios.ToList();
                return Page();
            }

            _context.Propietarios.Add(Propietario);
            _context.SaveChanges();

            return RedirectToPage("/Propietarios");
        }
    }
}
