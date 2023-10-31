using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Categorias
{
    public partial class DetalhesCategoria
    {
        public Categoria? Categoria { get; set; }

        [Inject]
        public ICategoriaService CategoriaService { get; set; }

        protected override void OnInitialized()
        {
           Categoria = new Categoria();
        }

        protected async Task SalvarCategoria()
        {
            if(Categoria != null)
            {
               await CategoriaService.SalvarCategoria(Categoria);
            }
            else
            {
                //Implementar Modal
            }
            
        }
    }
}
