using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldVeterinarios
{
    public class DetailsModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public DetailsModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public Veterinario Veterinario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinarios.FirstOrDefaultAsync(m => m.Id == id);

            if (veterinario is not null)
            {
                Veterinario = veterinario;

                return Page();
            }

            return NotFound();
        }
    }
}
