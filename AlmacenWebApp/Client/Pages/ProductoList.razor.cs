using System.Net.Http.Json;
using AlmacenWebApp.Shared;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace AlmacenWebApp.Client.Pages;

public partial class ProductoList
{
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    [Inject] public SweetAlertService Swal { get; set; } = default!;
    [Inject] public HttpClient HttpClient { get; set; } = default!;

    public ICollection<ProductoResponse>? Productos { get; set; } = new List<ProductoResponse>();

    protected override async Task OnInitializedAsync()
    {
        await CargarDatos();
    }

    private async Task CargarDatos()
    {
        var response = await HttpClient.GetFromJsonAsync<ICollection<ProductoResponse>>("api/productos");
        if (response is not null)
        {
            Productos = response;
        }
    }

    private void Crear()
    {
        NavigationManager.NavigateTo("/productos/crear");
    }

    private void Editar(int id)
    {
        NavigationManager.NavigateTo($"/productos/editar/{id}");
    }

    private async Task Eliminar(int id)
    {
        var result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Estas seguro?",
            Text = "No podras revertir esta accion",
            Icon = SweetAlertIcon.Question,
            ConfirmButtonText = "Si, eliminar",
            CancelButtonText = "Cancelar",
            ShowCancelButton = true
        });

        if (result.IsConfirmed)
        {
            await HttpClient.DeleteAsync($"api/Productos/{id}");
            await CargarDatos();
        }
    }
}