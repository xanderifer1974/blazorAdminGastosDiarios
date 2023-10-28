using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.UI.Pages.Categorias
{
    public partial class CategoriaPage
    {
        public List<Categoria> Categorias { get; set; }

        protected override void OnInitialized()
        {
            Categorias = new List<Categoria>();
            Categoria categoria1 = new Categoria { IdCategoria = 1, NomeCategoria = "Shopping" };
            Categoria categoria2 = new Categoria { IdCategoria = 2, NomeCategoria = "Combustível" };
            Categorias.Add(categoria1);
            Categorias.Add(categoria2);

        }
    }
}
