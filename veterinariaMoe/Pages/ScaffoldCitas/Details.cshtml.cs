using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldCitas
{
    public class DetailsModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public DetailsModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public Cita Cita { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FirstOrDefaultAsync(m => m.Id == id);

            if (cita is not null)
            {
                Cita = cita;

                return Page();
            }

            return NotFound();
        }
    }
}
