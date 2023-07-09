using System.ComponentModel.DataAnnotations;

namespace AlmacenWebApp.Shared;

public class ProductoDto
{
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(200)]
    public string Nombre { get; set; } = default!;

    [Required]
    [StringLength(20)]
    public string Codigo { get; set; } = default!;
    public decimal PrecioUnitario { get; set; }

    public int MarcaId { get; set; }

    #region Esto solo sirve para el frontend

    public string? Base64Imagen { get; set; }
    public string? NombreArchivo { get; set; }

    #endregion

    public string? UrlImagen { get; set; }

    public string? Descripcion { get; set; }
}