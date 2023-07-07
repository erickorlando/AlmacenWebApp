using AlmacenWebApp.Shared;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AlmacenWebApp.Client.Pages
{
    public partial class CategoriaList
    {

        [Inject] public HttpClient HttpClient { get; set; } = default!;
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;
        [Inject] public SweetAlertService Swal { get; set; } = default!;

        public List<CategoriaResponse>? Categorias { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            Categorias = await HttpClient.GetFromJsonAsync<List<CategoriaResponse>>("api/Categorias");
        }

        private void CrearCategoria()
        {
            NavigationManager.NavigateTo("/categorias/crear");
        }

        private void Editar(int id)
        {
            NavigationManager.NavigateTo($"/categorias/editar/{id}");
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
                await HttpClient.DeleteAsync($"api/Categorias/{id}");
                await CargarDatos();
            }
        }
    }
}
