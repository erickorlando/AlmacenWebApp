using AlmacenWebApp.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWebApp.Server.Datos;

public class AlmacenWebAppDbContext : DbContext
{
    public AlmacenWebAppDbContext(DbContextOptions<AlmacenWebAppDbContext> options)
    :base(options)
    {
        
    }

    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Marca> Marcas { get; set; } = null!;

    public DbSet<Venta> Ventas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>()
            .Property(p => p.Nombre)
            .HasMaxLength(100);

        modelBuilder.Entity<Categoria>()
            .Property(p => p.Descripcion)
            .HasMaxLength(200);

        modelBuilder.Entity<Producto>()
            .Property(p => p.Codigo)
            .HasMaxLength(20);
        
        modelBuilder.Entity<Producto>()
            .Property(p => p.Nombre)
            .HasMaxLength(200);

        modelBuilder.Entity<Producto>()
            .Property(p => p.PrecioUnitario)
            .HasPrecision(11, 2);

        modelBuilder.Entity<Marca>()
            .Property(p => p.Descripcion)
            .HasMaxLength(150);

        // Inicializamos una lista por default de Marcas
        modelBuilder.Entity<Marca>()
            .HasData(new List<Marca>()
            {
                new() { Id = 1, Descripcion = "Samsung" },
                new() { Id = 2, Descripcion = "LG" },
                new() { Id = 3, Descripcion = "Xiaomi" },
                new() { Id = 4, Descripcion = "Apple" },
                new() { Id = 5, Descripcion = "Honor" },
            });

        modelBuilder.Entity<Venta>()
            .Property(p => p.Precio)
            .HasPrecision(11, 2);

        modelBuilder.Entity<Venta>()
            .Property(p => p.NumeroFactura)
            .HasMaxLength(20);

        modelBuilder.Entity<Venta>()
            .Property(p => p.FechaVenta)
            .HasColumnType("date")
            .HasDefaultValueSql("GETDATE()");
    }
}