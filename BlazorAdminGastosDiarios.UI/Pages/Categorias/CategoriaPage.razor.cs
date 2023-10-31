using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Categorias
{
    public partial class CategoriaPage
    {
        [Inject]
        public ICategoriaService CategoriaService { get; set; }
        public IEnumerable<Categoria>? Categorias { get; set; }

        public string? Mensagem { get; set; }

        protected  async override Task OnInitializedAsync()
        {
            try
            {
                Categorias = await CategoriaService.ListarTodasCategorias();
            }
            catch (Exception ex)
            {
                Mensagem = $" Erro ao carregar lista de categorias : {ex.Message}";
            }
        }
    }
}
