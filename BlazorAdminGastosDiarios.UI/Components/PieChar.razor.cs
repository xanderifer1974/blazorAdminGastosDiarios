using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.Model.Enum;
using BlazorAdminGastosDiarios.UI.Interfaces;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.PieChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Components
{
    public partial class PieChar
    {
        [Inject]
        public IFinancaService FinancaService { get; set; }

        public IEnumerable<Financa> Financas { get; set; }

        public string Mensagem { get; set; }

        private PieConfig _Config;
        private ChartJsPieChart _pieChartJS;

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Financas = await FinancaService.ListarTodasFinancas();
            }
            catch (Exception e)
            {

               Mensagem = "Alguma coisa deu errado: " +  e.Message;
            }

            _Config = new PieConfig
            {
                Options = new PieOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Gráfico de Finanças"
                    },
                    Responsive = true,
                    Animation = new ArcAnimation
                    {
                        AnimateRotate = true,
                        AnimateScale = true,
                    }
                }

            };

            _Config.Data.Labels.AddRange(Financas.Select(c => c.Categoria.NomeCategoria).Distinct().ToArray());

            var pieSet = new PieDataset
            {
                BackgroundColor = new[] { ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString() },
                BorderWidth = 0,
                HoverBackgroundColor = ColorUtil.RandomColorString(),
                HoverBorderColor = ColorUtil.RandomColorString(),
                HoverBorderWidth = 1,
                BorderColor = "#ffffff"
            };

            pieSet.Data.AddRange(Financas.GroupBy(e => e.IdCategoria).Select(ec => ec.Sum(c => Convert.ToDouble(c.Valor))).ToArray());

            _Config.Data.Datasets.Add(pieSet);
        }

        protected decimal GetTotalDespesas()
        {
            return Financas
                   .Where(c => c.TipoFinanca == TipoFinancaEnum.Debito)
                   .GroupBy(i => 1)
                   .Select(g => new
                   {
                       Valor = g.Sum(i => i.Valor)
                   }).FirstOrDefault().Valor;
        }

        protected decimal GetTotalReceitas()
        {
            return Financas
                   .Where(c => c.TipoFinanca == TipoFinancaEnum.Credito)
                   .GroupBy(i => 1)
                   .Select(g => new
                   {
                       Valor = g.Sum(i => i.Valor)
                   }).FirstOrDefault().Valor;
        }

        protected decimal GetTotal()
        {
            return GetTotalReceitas() + GetTotalDespesas();
        }

        public string GetTotalColor()
        {
            string color = GetTotal() > 0 ? "green" : "red";
            return color;
        }


    }
}
