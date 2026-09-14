using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldMascotas
{
    public class DetailsModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public DetailsModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public Mascota Mascota { get; set; } = default!;
        public Propietario? Propietario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var mascota = await _context.Mascotas.FirstOrDefaultAsync(m => m.Id == id);
            if (mascota is not null)
            {
                Mascota = mascota;
                Propietario = await _context.Propietarios.FirstOrDefaultAsync(p => p.Id == mascota.PropietarioId);
                return Page();
            }

            return NotFound();
        }
    }
}
