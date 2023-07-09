namespace AlmacenWebApp.Shared;

public class VentaResponse
{
    public int Id { get; set; }
    public string Producto { get; set; } = null!;
    public int ProductoId { get; set; }
    public DateTime FechaVenta { get; set; }
    public string NumeroFactura { get; set; } = null!;
    public decimal Precio { get; set; }
}