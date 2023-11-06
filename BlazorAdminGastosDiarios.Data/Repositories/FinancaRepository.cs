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

        public async Task<bool> AtualizarDetalheFinanca(Financa financa)
        {
            var db = dbConection();
            var sql = @" UPDATE Financa
                          SET Descricao = @Descricao, Valor = @Valor, IdCategoria = @IdCategoria,
                              TipoFinanca = @TipoFinanca, DataFinanca = @DataFinanca
                              WHERE IdFinanca = @IdFinanca ";
            
            var result = await db.ExecuteAsync(sql,
                new { financa.Descricao, financa.Valor, financa.IdCategoria, financa.TipoFinanca, financa.DataFinanca });

            return result > 0;
        }

        public async Task<bool> DeletarDetalheFinanca(int id)
        {
            var db = dbConection();
            var sql = @" DELETE Financa
                         WHERE IdFinanca = @Id ";

            var resultado = await db.ExecuteAsync(sql, new { Id = id }); ;

            return resultado > 0;
        }

        public async Task<bool> InserirDetalheFinanca(Financa financa)
        {
            var db = dbConection();
            var sql = @" INSERT into Financa (Descricao, Valor, IdCategoria,TipoFinanca,DataFinanca)
                         VALUES (@Descricao, @Valor, @IdCategoria,@TipoFinanca,@DataFinanca) ";
            var result = await db.ExecuteAsync(sql,
                new { financa.Descricao, financa.Valor, financa.IdCategoria, financa.TipoFinanca, financa.DataFinanca });
            
            return result > 0;
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

        public async Task<Financa?> ObterDetalheFinanca(int id)
        {
            var db = dbConection();
            var sql = @"SELECT IdFinanca, Descricao, Valor, IdCategoria, TipoFinanca, DataFinanca
                        FROM Financa
                        WHERE IdFinanca =@IdFinanca";

            return await db.QueryFirstOrDefaultAsync<Financa>(sql, new { IdFinanca = id });
        }
    }
}
