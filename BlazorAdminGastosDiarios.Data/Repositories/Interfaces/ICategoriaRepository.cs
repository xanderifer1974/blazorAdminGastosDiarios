using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.Data.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ListarTodasCategorias();
        Task<Categoria> ObterCategoria(int id);
        Task<bool> InserirCategoria(Categoria categoria);
        Task<bool> AtualizarCategoria(Categoria categoria);
        Task<bool> DeletarCategoria(int id);
    }
}
