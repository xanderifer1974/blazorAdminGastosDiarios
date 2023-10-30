using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.UI.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ListarTodasCategorias();
        Task<Categoria?> ObterCategoria(int id);
        Task SalvarCategoria(Categoria categoria);        
        Task DeletarCategoria(int id);
    }
}
