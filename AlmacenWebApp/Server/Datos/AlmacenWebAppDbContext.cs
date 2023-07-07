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


    }
}