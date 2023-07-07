using AlmacenWebApp.Entidades;
using AlmacenWebApp.Server.Datos;
using AlmacenWebApp.Shared;

namespace AlmacenWebApp.Server.Servicios;

public class ProductoServicio
{
    private readonly AlmacenWebAppDbContext _context;
    private readonly IFileUploader _fileUploader;

    public ProductoServicio(AlmacenWebAppDbContext context, IFileUploader fileUploader)
    {
        _context = context;
        _fileUploader = fileUploader;
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

    public async Task Agregar(ProductoDto producto)
    {
        var registro = new Producto()
        {
            CategoriaId = producto.CategoriaId,
            MarcaId = producto.MarcaId,
            Nombre = producto.Nombre,
            Codigo = producto.Codigo,
            PrecioUnitario = producto.PrecioUnitario
        };

        registro.UrlImagen = await _fileUploader.SubirArchivo(producto.Base64Imagen, producto.NombreArchivo);

        _context.Productos.Add(registro);

        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(int id, ProductoDto producto)
    {
        var registroExistente = ObtenerPorId(id);
        if (registroExistente != null)
        {
            registroExistente.Nombre = producto.Nombre;
            registroExistente.Codigo = producto.Codigo;
            registroExistente.PrecioUnitario = producto.PrecioUnitario;
            registroExistente.CategoriaId = producto.CategoriaId;
            registroExistente.MarcaId = producto.MarcaId;

            if (!string.IsNullOrWhiteSpace(producto.NombreArchivo))
            {
                registroExistente.UrlImagen =
                    await _fileUploader.SubirArchivo(producto.Base64Imagen, producto.NombreArchivo);
            }

            await _context.SaveChangesAsync(); // Confirmar los cambios
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