using System.ComponentModel.DataAnnotations;

namespace veterinariaMoe.Modelos
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El propietario es obligatorio")]
        [Display(Name = "Propietario")]
        public int PropietarioId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(75, ErrorMessage = "El nombre no puede exceder los 75 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La especie es obligatoria")]
        [StringLength(50, ErrorMessage = "La especie no puede exceder los 50 caracteres")]
        [Display(Name = "Especie")]
        public string Especie { get; set; } = "";

        [StringLength(75, ErrorMessage = "La raza no puede exceder los 75 caracteres")]
        [Display(Name = "Raza")]
        public string? Raza { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;
    }
}
