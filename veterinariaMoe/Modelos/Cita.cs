namespace veterinariaMoe.Modelos
{
    public class Cita
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }
        public string NombreVeterinario { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Hora { get; set; } = "";
        public string Motivo { get; set; } = "";
        public string EstadoCita { get; set; } = "pendiente";
        public string Diagnostico { get; set; } = "";
    }
}
