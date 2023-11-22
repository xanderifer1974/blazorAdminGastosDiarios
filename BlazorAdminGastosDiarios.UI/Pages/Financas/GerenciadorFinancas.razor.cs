using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.UI.Pages.Financas
{
    public partial class GerenciadorFinancas: IDisposable
    {
        public Financa? Financa { get; set; } 


        protected override Task OnInitializedAsync()
        {
            Financa = new Financa();
            Financa.OnSelectedFinancaChanged += StateHasChanged;

            return base.OnInitializedAsync();
        }

        public void Dispose()
        {
            Financa.OnSelectedFinancaChanged -= StateHasChanged;
        }
    }
}
