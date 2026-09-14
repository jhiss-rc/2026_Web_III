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
    public class IndexModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public IndexModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public IList<Cita> Cita { get; set; } = default!;
        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Veterinario> ListaVeterinarios { get; set; } = new();
        public List<Propietario> ListaPropietarios { get; set; } = new();

        public async Task OnGetAsync()
        {
            Cita = await _context.Citas.ToListAsync();
            ListaMascotas = await _context.Mascotas.ToListAsync();
            ListaVeterinarios = await _context.Veterinarios.ToListAsync();
            ListaPropietarios = await _context.Propietarios.ToListAsync();
        }
    }
}
