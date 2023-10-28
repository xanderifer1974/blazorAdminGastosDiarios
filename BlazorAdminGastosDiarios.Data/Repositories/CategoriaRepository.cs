using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
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

            //Parei na aula 21 - 08:16

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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ListarTodasCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
