using System.ComponentModel.DataAnnotations;

namespace veterinariaMoe.Modelos
{
    public class Propietario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(75, ErrorMessage = "El nombre no puede exceder los 75 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100, ErrorMessage = "Los apellidos no pueden exceder los 100 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = "";

        [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [StringLength(150, ErrorMessage = "El correo no puede exceder los 150 caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;
    }
}
