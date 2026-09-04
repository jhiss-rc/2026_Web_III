using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using veterinariaMoe.Datos;
using veterinariaMoe.Modelos;

namespace veterinariaMoe.Pages
{
    public class CitasModel : PageModel
    {
        [BindProperty]
        public int MascotaId { get; set; }

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

        public List<Cita> ListaCitas { get; set; } = new();
        public List<Mascota> ListaMascotas { get; set; } = new();

        public void OnGet()
        {
            ListaCitas = BaseDatos.Citas;
            ListaMascotas = BaseDatos.Mascotas;
        }

        public IActionResult OnPost()
        {
            var nuevaCita = new Cita
            {
                Id                 = BaseDatos.Citas.Count + 1,
                MascotaId          = MascotaId,
                VeterinarioId      = 0,
                NombreVeterinario  = Veterinario,
                Fecha              = Fecha,
                Hora               = Hora,
                Motivo             = Motivo,
                EstadoCita         = EstadoCita,
                Diagnostico        = Diagnostico
            };

            BaseDatos.Citas.Add(nuevaCita);

            return RedirectToPage("/Citas");
        }
    }
}
