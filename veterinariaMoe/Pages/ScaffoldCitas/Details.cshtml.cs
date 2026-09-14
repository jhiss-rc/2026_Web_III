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
        public Mascota? Mascota { get; set; }
        public Propietario? Propietario { get; set; }
        public Veterinario? Veterinario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var cita = await _context.Citas.FirstOrDefaultAsync(m => m.Id == id);
            if (cita is not null)
            {
                Cita = cita;
                Mascota = await _context.Mascotas.FirstOrDefaultAsync(m => m.Id == cita.MascotaId);
                if (Mascota != null)
                    Propietario = await _context.Propietarios.FirstOrDefaultAsync(p => p.Id == Mascota.PropietarioId);
                Veterinario = await _context.Veterinarios.FirstOrDefaultAsync(v => v.Id == cita.VeterinarioId);
                return Page();
            }

            return NotFound();
        }
    }
}
