using AlmacenWebApp.Entidades;
using AlmacenWebApp.Server.Datos;
using AlmacenWebApp.Shared;

namespace AlmacenWebApp.Server.Servicios;

public class ProductoServicio
{
    private readonly AlmacenWebAppDbContext _context;

    public ProductoServicio(AlmacenWebAppDbContext context)
    {
        _context = context;
    }

    public List<ProductoResponse> Listar()
    {
        return _context.Productos
            .Select(p => new ProductoResponse()
            {
                Id = p.Id,
                CategoriaId = p.CategoriaId,
                Categoria = p.Categoria.Nombre,
                Marca = p.Marca.Descripcion,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                PrecioUnitario = p.PrecioUnitario
            })
            .ToList();
    }

    public void Agregar(ProductoDto producto)
    {
        var registro = new Producto()
        {
            CategoriaId = producto.CategoriaId,
            MarcaId = producto.MarcaId,
            Nombre = producto.Nombre,
            Codigo = producto.Codigo,
            PrecioUnitario = producto.PrecioUnitario
        };
        _context.Productos.Add(registro);

        _context.SaveChanges();
    }

    public void Actualizar(int id, ProductoDto producto)
    {
        var registroExistente = ObtenerPorId(id);
        if (registroExistente != null)
        {
            registroExistente.Nombre = producto.Nombre;
            registroExistente.Codigo = producto.Codigo;
            registroExistente.PrecioUnitario = producto.PrecioUnitario;
            registroExistente.CategoriaId = producto.CategoriaId;
            registroExistente.MarcaId = producto.MarcaId;

            _context.SaveChanges(); // Confirmar los cambios
        }
    }

    public Producto? ObtenerPorId(int id)
    {
        return _context.Productos.Find(id);
    }

    public void Eliminar(int id)
    {
        var registro = ObtenerPorId(id);
        if (registro is not null)
        {
            _context.Productos.Remove(registro);
            _context.SaveChanges(); // Confirmo los cambios
        }
    }
}