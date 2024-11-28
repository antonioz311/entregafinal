namespace GestionInventario.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = "Auxiliar"; // Rol por defecto (Auxiliar)

        public bool EsAdministrador => Rol.Equals("Administrador", System.StringComparison.OrdinalIgnoreCase);
    }
}
