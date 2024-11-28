using System;

namespace GestionInventario.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Tipo { get; set; } = null!;
        public int Cantidad { get; set; }
        public string Motivo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal ValorUnitario { get; set; }

        public Producto Producto { get; set; } = null!;
    }
}

