using System.ComponentModel.DataAnnotations;

namespace BlazorAdminGastosDiarios.Model
{
   public class Categoria
    {
        public int IdCategoria { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="O nome da categoria é obrigatório.")]
        public string NomeCategoria { get; set; }
    }
}
