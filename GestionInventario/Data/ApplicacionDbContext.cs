using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;

namespace GestionInventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public required DbSet<Producto> Productos { get; set; } = null!;
        public required DbSet<Movimiento> Movimientos { get; set; } = null!;
        public required DbSet<Usuario> Usuarios { get; set; } = null!;
        public required DbSet<Proveedor> Proveedores { get; set; } = null!;
    
    }
}
