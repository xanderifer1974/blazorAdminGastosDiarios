using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using System.Text.Json;
using System.Text;

namespace BlazorAdminGastosDiarios.UI.Services
{
    public class FinancaService : IFinancaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "/api/Financa";

        public FinancaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletarDetalheFinanca(int id)
        {
            await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
        }

        public async Task<IEnumerable<Financa>> ListarTodasFinancas()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Financa>>($"{_baseAddress}");

            if (response == null)
            {
                throw new ApplicationException("O retorno de finanças é nulo.");
            }

            return response;
        }

        public async Task<Financa?> ObterDetalheFinanca(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Financa>($"{_baseAddress}/{id}");

            if (response == null)
            {
                throw new ApplicationException("O retorno de finanças é nulo.");
            }

            return response;
        }

        public async Task SalvarDetalheFinança(Financa financa)
        {
            var financaJson = new StringContent(JsonSerializer.Serialize(financa),
               Encoding.UTF8, "application/json");

            if (financa.IdFinanca == 0)
            {
                await _httpClient.PostAsync($"{_baseAddress}", financaJson);
            }
            else
            {
                await _httpClient.PutAsync($"{_baseAddress}", financaJson);
            }
        }
    }
}
