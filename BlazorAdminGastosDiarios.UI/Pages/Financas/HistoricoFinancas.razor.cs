using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.Model.Enum;
using BlazorAdminGastosDiarios.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Pages.Financas
{
    public partial class HistoricoFinancas
    {
        [Inject]
        public IFinancaService? FinancaServico { get; set; }

        public IEnumerable<Financa> Financas { get; set; }

        [CascadingParameter]
        public Financa? SelectedFinanca { get; set; }

        public string? Mensagem { get; set; }

        protected async Task SelectedFinancaChange(int financaId)
        {
            var financa =  await FinancaServico.ObterDetalheFinanca(financaId);

            SelectedFinanca.SelectedFinancaChanged(financa);
        }


        protected override async Task OnParametersSetAsync()
        {
            try
            {
                
                Financas = await FinancaServico.ListarTodasFinancas();
            }
            catch (Exception e)
            {

                Mensagem = "Algo saiu errado! " + e.Message;
            }
        }

        protected string GetTextColor(int financaId)
        {
            var financa = Financas.FirstOrDefault(e => e.IdFinanca ==  financaId);

            return financa.TipoFinanca == TipoFinancaEnum.Credito ? "color:green" : "color:red";
        }

    }
}
