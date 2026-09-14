using System.ComponentModel.DataAnnotations;

namespace veterinariaMoe.Modelos
{
    public class Veterinario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(75, ErrorMessage = "El nombre no puede exceder los 75 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(75, ErrorMessage = "Los apellidos no pueden exceder los 75 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = "";

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(75, ErrorMessage = "La especialidad no puede exceder los 75 caracteres")]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; } = "";

        [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;
    }
}
