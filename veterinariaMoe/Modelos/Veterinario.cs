namespace veterinariaMoe.Modelos
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string Especialidad { get; set; } = "";
        public string Telefono { get; set; } = "";
        public bool Estado { get; set; } = true;
    }
}
