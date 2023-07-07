namespace AlmacenWebApp.Shared;

public class ProductoResponse
{
    public int Id { get; set; }
    public string Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
    public string Nombre { get; set; } = default!;
    public string Codigo { get; set; } = default!;
    public decimal PrecioUnitario { get; set; }
}