using System.ComponentModel.DataAnnotations;

namespace bibliotecaUnivalle.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(150, ErrorMessage = "El autor no puede exceder los 150 caracteres")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        [StringLength(20, ErrorMessage = "El ISBN no puede exceder los 20 caracteres")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder los 100 caracteres")]
        [Display(Name = "Categoría")]
        // Corresponde al catálogo: Novela, Ciencia, Historia, Tecnología, etc.
        public string Catalogo { get; set; }

        [Required(ErrorMessage = "El año de publicación es obligatorio")]
        [Display(Name = "Año de Publicación")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "La cantidad disponible es obligatoria")]
        [Display(Name = "Cantidad Disponible")]
        public int CantidadDisponible { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;

        // Relación: un libro puede estar en muchos préstamos
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
