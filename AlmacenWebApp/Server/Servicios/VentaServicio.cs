using AlmacenWebApp.Entidades;
using AlmacenWebApp.Server.Datos;
using AlmacenWebApp.Shared;

namespace AlmacenWebApp.Server.Servicios;

public class VentaServicio
{
    private readonly AlmacenWebAppDbContext _context;

    public VentaServicio(AlmacenWebAppDbContext context)
    {
        _context = context;
    }

    public List<VentaResponse> GetList()
    {
        return _context.Ventas.OrderBy(p => p.NumeroFactura)
            .Select(p => new VentaResponse
            {
                Id = p.Id,
                FechaVenta = p.FechaVenta,
                Producto = p.Producto.Nombre,
                Precio = p.Precio,
                NumeroFactura = p.NumeroFactura,
            })
            .ToList();
    }

    public void CrearVenta(VentaDto request)
    {
        var venta = new Venta()
        {
            ProductoId = request.ProductoId,
            Precio = request.Precio
        };

        // Generamos el numero de factura
        var numero = _context.Ventas.Count() +1;
        // FAC-0000004
        venta.NumeroFactura = $"FAC-{numero:0000000}";

        _context.Ventas.Add(venta);
        _context.SaveChanges();
    }
}