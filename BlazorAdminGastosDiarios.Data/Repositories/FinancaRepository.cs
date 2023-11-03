using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
using Dapper;
using System.Data.SqlClient;

namespace BlazorAdminGastosDiarios.Data.Repositories
{
    public class FinancaRepository : IFinancaRepository
    {
        private readonly SqlConfiguration _connectionString;

        public FinancaRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public Task<bool> AtualizarDetalheFinanca(Financa financa)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletarDetalheFinanca(int id)
        {
            var db = dbConection();
            var sql = @" DELETE Financa
                         WHERE IdFinanca = @Id ";

            var resultado = await db.ExecuteAsync(sql, new { Id = id }); ;

            return resultado > 0;
        }

        public Task<bool> InserirDetalheFinanca(Financa financa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Financa>> ListarTodasFinancas()
        {
            var db = dbConection();
            var sql = @" SELECT f.IdFinanca,f.Descricao,f.Valor, f.IdCategoria, f.TipoFinanca,f.DataFinanca,
                         c.IdCategoria, c.NomeCategoria
                         FROM Financa F
                         INNER JOIN Categoria c ON f.IdCategoria = c.IdCategoria"; 
            db.Open();
            var result =  await db.QueryAsync<Financa,Categoria,Financa>(sql,
                ((fincanca,categoria) =>
                {
                    fincanca.Categoria = categoria;
                    return fincanca;
                }), new { }, splitOn:"IdCategoria");

            return result;
        }

        //Parei no vídeo 43 - 13:59

        public Task<Financa> ObterDetalheFinanca(int id)
        {
            throw new NotImplementedException();
        }
    }
}
