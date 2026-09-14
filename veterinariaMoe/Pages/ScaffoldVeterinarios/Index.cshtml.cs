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
    public class IndexModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public IndexModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public IList<Veterinario> Veterinario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Veterinario = await _context.Veterinarios.ToListAsync();
        }
    }
}
