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
    public class IndexModel : PageModel
    {
        private readonly veterinariaMoe.Datos.VeterinariaContext _context;

        public IndexModel(veterinariaMoe.Datos.VeterinariaContext context)
        {
            _context = context;
        }

        public IList<Propietario> Propietario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Propietario = await _context.Propietarios.ToListAsync();
        }
    }
}
