using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace veterinariaMoe.Pages
{
    public class CitasModel : PageModel
    {
        [BindProperty]
        public string Mascota { get; set; } = "";

        [BindProperty]
        public string Veterinario { get; set; } = "";

        [BindProperty]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [BindProperty]
        public string Hora { get; set; } = "";

        [Required]
        [BindProperty]
        public string Motivo { get; set; } = "";

        [BindProperty]
        public string EstadoCita { get; set; } = "pendiente";

        [BindProperty]
        public string Diagnostico { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
