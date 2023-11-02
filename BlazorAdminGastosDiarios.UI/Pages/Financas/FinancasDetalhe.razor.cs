using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Financas
{
    public partial class FinancasDetalhe
    {
        [Inject]
        public ICategoriaService CategoriaService { get; set; }
        private Financa Financa { get; set; } = new Financa();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();

        protected  async override Task OnInitializedAsync()
        {
            Categorias = await CategoriaService.ListarTodasCategorias();
        }
    }
}
