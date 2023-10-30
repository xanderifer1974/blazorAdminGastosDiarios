using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using System.Text.Json;

namespace BlazorAdminGastosDiarios.UI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "api/Categoria";

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletarCategoria(int id)
        {
            await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
        }

        public async Task<IEnumerable<Categoria>> ListarTodasCategorias()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>($"{_baseAddress}");

            if (response == null)
            {
                throw new ApplicationException("O retorno de categorias é nula.");
            }

            return response;
        }

        public Task<Categoria?> ObterCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task SalvarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
