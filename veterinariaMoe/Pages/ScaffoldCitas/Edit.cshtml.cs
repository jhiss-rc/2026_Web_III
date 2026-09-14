using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages_ScaffoldCitas
{
    public class EditModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public EditModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = default!;
        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Veterinario> ListaVeterinarios { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var cita = await _context.Citas.FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null) return NotFound();

            Cita = cita;
            ListaMascotas = _context.Mascotas.ToList();
            ListaVeterinarios = _context.Veterinarios.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ListaMascotas = _context.Mascotas.ToList();
                ListaVeterinarios = _context.Veterinarios.ToList();
                return Page();
            }

            _context.Attach(Cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(Cita.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.Id == id);
        }
    }
}
