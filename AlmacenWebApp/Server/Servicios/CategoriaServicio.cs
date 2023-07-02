using AlmacenWebApp.Server.Datos;
using AlmacenWebApp.Shared;

namespace AlmacenWebApp.Server.Servicios;

public class CategoriaServicio
{
    private readonly AlmacenWebAppDbContext _context;
    //private readonly List<Categoria> _categorias;

    public CategoriaServicio(AlmacenWebAppDbContext context)
    {
        _context = context;
        //_categorias = new List<Categoria>()
        //{
        //    new Categoria() { Id = 1, Nombre = "Frutas", Descripcion = "Frutas frescas" },
        //    new Categoria() { Id = 2, Nombre = "Verduras", Descripcion = "Verduras de la estacion" },
        //};
    }

    public List<Categoria> Listar()
    {
        return _context.Categorias.ToList();
    }

    public void Agregar(Categoria categoria)
    {
        //categoria.Id = _categorias.Count + 1;
        _context.Categorias.Add(categoria);

        _context.SaveChanges();
    }

    public void Actualizar(int id, Categoria categoria)
    {
        var registroExistente = ObtenerPorId(id);
        if (registroExistente != null)
        {
            registroExistente.Nombre = categoria.Nombre;
            registroExistente.Descripcion = categoria.Descripcion;

            _context.SaveChanges(); // Confirmar los cambios
        }
    }

    public Categoria? ObtenerPorId(int id)
    {
        return _context.Categorias.Find(id);
    }

    public void Eliminar(int id)
    {
        var registro = ObtenerPorId(id);
        if (registro is not null)
        {
            _context.Categorias.Remove(registro);
            _context.SaveChanges(); // Confirmo los cambios
        }
    }
}