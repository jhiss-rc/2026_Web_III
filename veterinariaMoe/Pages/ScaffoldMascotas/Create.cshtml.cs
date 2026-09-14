using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldMascotas
{
    public class CreateModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public CreateModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public List<Propietario> ListaPropietarios { get; set; } = new();

        public IActionResult OnGet()
        {
            ListaPropietarios = _context.Propietarios.ToList();
            return Page();
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mascotas.Add(Mascota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
