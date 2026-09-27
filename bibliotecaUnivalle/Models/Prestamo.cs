using System.ComponentModel.DataAnnotations;

namespace bibliotecaUnivalle.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El libro es obligatorio")]
        [Display(Name = "Libro")]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "La fecha de préstamo es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime FechaPrestamo { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "La fecha de devolución es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime FechaDevolucion { get; set; }

        [StringLength(50, ErrorMessage = "El estado no puede exceder los 50 caracteres")]
        [Display(Name = "Estado del Préstamo")]
        // Valores posibles: "Activo", "Devuelto", "Vencido"
        public string EstadoPrestamo { get; set; } = "Activo";

        // Relaciones de navegación
        public Usuario? Usuario { get; set; }
        public Libro? Libro { get; set; }
    }
}
