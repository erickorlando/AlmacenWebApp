using AlmacenWebApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AlmacenWebApp.Client.Shared.ProductoComponents;

public partial class ProductoEdit

{
    [Parameter]
    public ProductoDto Producto { get; set; } = new ProductoDto();

    [Parameter]
    public ICollection<CategoriaResponse> Categorias { get; set; } = new List<CategoriaResponse>();

    [Parameter] 
    public ICollection<MarcaResponse> Marcas { get; set; } = new List<MarcaResponse>();

    [Parameter]
    public EventCallback GuardarCallback { get; set; }

    private async Task Guardar()
    {
        await GuardarCallback.InvokeAsync();
    }


    private async Task OnFileUploaded(InputFileChangeEventArgs e)
    {
        try
        {
            var imagen = e.File;
            var buffer = new byte[imagen.Size];
            var _ = await imagen.OpenReadStream().ReadAsync(buffer);

            Producto.Base64Imagen = Convert.ToBase64String(buffer);
            Producto.NombreArchivo = imagen.Name;
            Producto.UrlImagen = null;
        }
        catch (Exception ex)
        {
            await Swal.FireAsync("Error de archivo", ex.Message);
        }
    }

}