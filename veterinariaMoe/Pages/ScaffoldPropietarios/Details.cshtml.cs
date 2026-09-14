using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldPropietarios
{
    public class DetailsModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public DetailsModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public Propietario Propietario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FirstOrDefaultAsync(m => m.Id == id);

            if (propietario is not null)
            {
                Propietario = propietario;

                return Page();
            }

            return NotFound();
        }
    }
}
