using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.Model.Enum;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Financas
{
    public partial class FinancasDetalhe
    {
        [Inject]
        public ICategoriaService CategoriaService { get; set; }

        [Inject]
        public IFinancaService FinancaService { get; set; }
        public Financa Financa { get; set; } = new Financa();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();

        [Parameter]
        public TipoFinancaEnum TipoFinanca { get; set; }

        protected  async override Task OnInitializedAsync()
        {
            Categorias = await CategoriaService.ListarTodasCategorias();

            Financa.IdCategoria = Categorias.FirstOrDefault().IdCategoria;
            Financa.TipoFinanca = TipoFinanca;

        }

        protected async Task SalvarFinanca()
        {
            await FinancaService.SalvarDetalheFinança(Financa);
        }




    }
}
