using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.UI.Interfaces;
using System.Text;
using System.Text.Json;

namespace BlazorAdminGastosDiarios.UI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "/api/Categoria";

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

        public async Task<Categoria?> ObterCategoria(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Categoria>($"{_baseAddress}/{id}");

            if (response == null)
            {
                throw new ApplicationException("O retorno de categorias é nula.");
            }

            return response;
        }

        public async Task SalvarCategoria(Categoria categoria)
        {
            var categoriaJson = new StringContent(JsonSerializer.Serialize(categoria),
                Encoding.UTF8, "application/json");

            if(categoria.IdCategoria == 0)
            {
               await _httpClient.PostAsync($"{_baseAddress}", categoriaJson);
            }
            else
            {
              await  _httpClient.PutAsync($"{_baseAddress}", categoriaJson);
            }
        }
    }
}
