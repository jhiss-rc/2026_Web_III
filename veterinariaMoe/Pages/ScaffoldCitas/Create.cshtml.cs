using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldCitas
{
    public class CreateModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public CreateModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Veterinario> ListaVeterinarios { get; set; } = new();

        public IActionResult OnGet()
        {
            ListaMascotas = _context.Mascotas.ToList();
            ListaVeterinarios = _context.Veterinarios.ToList();
            return Page();
        }

        [BindProperty]
        public Cita Cita { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ListaMascotas = _context.Mascotas.ToList();
                ListaVeterinarios = _context.Veterinarios.ToList();
                return Page();
            }

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
