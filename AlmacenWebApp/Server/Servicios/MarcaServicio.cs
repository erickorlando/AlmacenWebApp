using AlmacenWebApp.Server.Datos;
using AlmacenWebApp.Shared;

namespace AlmacenWebApp.Server.Servicios;

public class MarcaServicio
{
    private readonly AlmacenWebAppDbContext _context;

    public MarcaServicio(AlmacenWebAppDbContext context)
    {
        _context = context;
    }

    public List<MarcaResponse> List()
    {
        return _context.Marcas
            .Select(p => new MarcaResponse
            {
                Id = p.Id,
                Descripcion = p.Descripcion
            })
            .ToList();
    }
}