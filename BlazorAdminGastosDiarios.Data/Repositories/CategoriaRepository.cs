using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
using Dapper;
using System.Data.SqlClient;

namespace BlazorAdminGastosDiarios.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private SqlConfiguration _connectionString;

        public CategoriaRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
           

        }
        public async Task<bool> AtualizarCategoria(Categoria categoria)
        {
            var db = dbConection();
            var sql = @" UPDATE Categoria
                        SET NomeCategoria = @NomeCategoria 
                        WHERE IdCategoria = @IdCategoria";
            var resultado = await db.ExecuteAsync(sql, new { categoria.NomeCategoria, categoria.IdCategoria });

            return resultado > 0;
        }

        public async Task<bool> DeletarCategoria(int id)
        {
            var db = dbConection();
            var sql = @" DELETE Categoria
                         WHERE IdCategoria = @Id ";

            var resultado = await db.ExecuteAsync(sql, new { Id = id }); ;

            return resultado > 0;
        }

        public async Task<bool> InserirCategoria(Categoria categoria)
        {
            var db = dbConection();
            var sql = @" INSERT into Categoria (NomeCategoria)
                         VALUES (@NomeCategoria)";

            var resultado = await db.ExecuteAsync(sql, new { categoria.NomeCategoria,categoria.IdCategoria });

            return resultado > 0;
        }

        public async Task<IEnumerable<Categoria>> ListarTodasCategorias()
        {
           var db = dbConection();
           var sql = @"SELECT IdCategoria,NomeCategoria
                        FROM Categoria";
           db.Open();
           return await db.QueryAsync<Categoria>(sql, new {});

        }

        public async Task<Categoria?> ObterCategoria(int id)
        {
            var db = dbConection();
            var sql = @"SELECT IdCategoria,NomeCategoria
                        FROM Categoria WHERE IdCategoria = @Id ";
            var categoria = await db.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id });
            return categoria;
        }
    }
}
