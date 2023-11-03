using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.Data.Repositories.Interfaces
{
    public interface IFinancaRepository
    {
        Task<IEnumerable<Financa>> ListarTodasFinancas();
        Task<Financa> ObterDetalheFinanca(int id);
        Task<bool> InserirDetalheFinanca(Financa financa);
        Task<bool> AtualizarDetalheFinanca(Financa financa);
        Task<bool> DeletarDetalheFinanca(int id);
    }
}
