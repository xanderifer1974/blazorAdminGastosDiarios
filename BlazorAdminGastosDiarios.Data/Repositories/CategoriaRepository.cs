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
        public Task<bool> AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InserirCategoria(Categoria categoria)
        {
            //Continuar deste método
            // Parei na aula 21 - Minuto 17:14
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Categoria>> ListarTodasCategorias()
        {
           var db = dbConection();
           var sql = @"SELECT IdCategoria,NomeCategoria
                        FROM Categoria";
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
