namespace GestionInventario.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public bool Procesado { get; set; }
    }
}
