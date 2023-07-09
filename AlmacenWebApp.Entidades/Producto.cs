namespace AlmacenWebApp.Entidades;

public class Producto
{
    public int Id { get; set; }
    public Categoria Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }

    public Marca Marca { get; set; } = default!;
    public int MarcaId { get; set; }

    public string Nombre { get; set; } = default!;
    public string Codigo { get; set; } = default!;
    public decimal PrecioUnitario { get; set; }
    public string? UrlImagen { get; set; }

    public string? Descripcion { get; set; }
}