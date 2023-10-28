using BlazorAdminGastosDiarios.Model;

namespace BlazorAdminGastosDiarios.UI.Pages.Categorias
{
    public partial class DetalhesCategoria
    {
        public Categoria Categoria { get; set; }

        protected override void OnInitialized()
        {
           Categoria = new Categoria();
        }

        protected void SalvarCategoria()
        {

        }
    }
}
