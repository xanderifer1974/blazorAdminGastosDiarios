using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Categorias
{
    public partial class DetalhesCategoria
    {
      
        [Inject]
        public ICategoriaService CategoriaService { get; set; } 

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public int id { get; set; }

        public Categoria? Categoria { get; set; } = new Categoria();

        protected async override Task OnInitializedAsync()
        {
            if(id > 0) //Nesse caso trata-se de uma edição.
            {
                Categoria = await CategoriaService.ObterCategoria(id);
            }
        }

        protected async Task SalvarCategoria()
        {
            if(Categoria != null)
            {
               await CategoriaService.SalvarCategoria(Categoria);
                Navigation.NavigateTo("/categorias");
            }
            else
            {
                //Implementar Modal
            }            
        }

        public void Cancelar()
        {
            Navigation.NavigateTo("/categorias");
        }
    }
}
