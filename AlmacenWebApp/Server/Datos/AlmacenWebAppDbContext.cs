using AlmacenWebApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWebApp.Server.Datos;

public class AlmacenWebAppDbContext : DbContext
{
    public AlmacenWebAppDbContext(DbContextOptions<AlmacenWebAppDbContext> options)
    :base(options)
    {
        
    }

    public DbSet<Categoria> Categorias { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>()
            .Property(p => p.Nombre)
            .HasMaxLength(100);
        
        modelBuilder.Entity<Categoria>()
            .Property(p => p.Descripcion)
            .HasMaxLength(200);
    }
}