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

        [CascadingParameter]
        protected Financa Financa { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();

        [Parameter]
        public TipoFinancaEnum TipoFinanca { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categorias = await CategoriaService.ListarTodasCategorias();

            if (Financa.IdFinanca == 0)
            {
                Financa.IdCategoria = Categorias.FirstOrDefault().IdCategoria;
                Financa.TipoFinanca = TipoFinanca;
            }


        }

        protected async Task SalvarFinanca()
        {
            await FinancaService.SalvarDetalheFinança(Financa);
            ClearFinanca();
            Financa.SelectedFinancaChanged(Financa);
        }

        protected string GetCancelButtonStyle()
        {
            return Financa.IdFinanca == 0 ? "display:none" : "";
        }


        public void Cancel()
        {
           ClearFinanca();
        }

        private void ClearFinanca()
        {
            Financa.IdFinanca = 0;
            Financa.Descricao = "";
            Financa.Valor = 0;
            Financa.DataFinanca = DateTime.MinValue;
            Financa.IdCategoria = Categorias.FirstOrDefault().IdCategoria;
            Financa.TipoFinanca = TipoFinanca;
        }

    }
}
