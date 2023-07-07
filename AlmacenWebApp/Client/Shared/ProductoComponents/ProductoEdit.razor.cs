using AlmacenWebApp.Shared;
using Microsoft.AspNetCore.Components;

namespace AlmacenWebApp.Client.Shared.ProductoComponents;

public partial class ProductoEdit

{
    [Parameter]
    public ProductoDto Producto { get; set; } = new ProductoDto();

    [Parameter]
    public ICollection<CategoriaResponse> Categorias { get; set; } = new List<CategoriaResponse>();

    [Parameter]
    public EventCallback GuardarCallback { get; set; }

    private async Task Guardar()
    {
        await GuardarCallback.InvokeAsync();
    }
}