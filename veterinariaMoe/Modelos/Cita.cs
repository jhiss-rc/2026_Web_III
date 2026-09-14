using System.ComponentModel.DataAnnotations;

namespace veterinariaMoe.Modelos
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La mascota es obligatoria")]
        [Display(Name = "Mascota")]
        public int? MascotaId { get; set; }

        [Required(ErrorMessage = "El veterinario es obligatorio")]
        [Display(Name = "Veterinario")]
        public int? VeterinarioId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "La hora es obligatoria")]
        [Display(Name = "Hora")]
        public string Hora { get; set; } = "";

        [Required(ErrorMessage = "El motivo es obligatorio")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder los 200 caracteres")]
        [Display(Name = "Motivo")]
        public string Motivo { get; set; } = "";

        [Display(Name = "Estado")]
        public string EstadoCita { get; set; } = "pendiente";

        [StringLength(500, ErrorMessage = "El diagnóstico no puede exceder los 500 caracteres")]
        [Display(Name = "Diagnóstico")]
        public string? Diagnostico { get; set; }
    }
}
