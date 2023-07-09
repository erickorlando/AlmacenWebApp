namespace AlmacenWebApp.Entidades;

public class Venta
{
    public int Id { get; set; }
    public Producto Producto { get; set; } = null!;
    public int ProductoId { get; set; }
    public DateTime FechaVenta { get; set; }
    public string NumeroFactura { get; set; } = null!;
    public decimal Precio { get; set; }
}