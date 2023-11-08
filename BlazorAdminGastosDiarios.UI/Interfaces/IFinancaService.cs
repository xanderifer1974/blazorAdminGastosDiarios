using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.UI.Interfaces
{
    public interface IFinancaService
    {
        Task<IEnumerable<Financa>> ListarTodasFinancas();
        Task<Financa?> ObterDetalheFinanca(int id);
        Task SalvarDetalheFinança(Financa financa);
        Task DeletarDetalheFinanca(int id);
    }
}
