namespace GestionInventario.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int NivelMaximo { get; set; }
        public int NivelMinimo { get; set; }
    }
}
