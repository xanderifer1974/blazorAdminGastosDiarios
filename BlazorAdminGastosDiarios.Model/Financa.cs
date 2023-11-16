using BlazorAdminGastosDiarios.Model.Enum;
using BlazorAdminGastosDiarios.Model.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorAdminGastosDiarios.Model
{
    public class Financa : IValidatableObject
    {
        public int IdFinanca { get; set; }

        [Required(ErrorMessage ="O nome da transação deve ser preenchido.")]
        public string? Descricao { get; set; }

        [Required]        
        public decimal Valor { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        public Categoria? Categoria { get; set; } = null;

        public TipoFinancaEnum TipoFinanca { get; set; }

        [Required(ErrorMessage ="A data deve ser informada.")]
        [FinacaDataTransacaoValidator(DiasNoFuturo =30)]
        public DateTime DataFinanca { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (TipoFinanca == TipoFinancaEnum.Credito && Valor < 0)
            {
                errors.Add(new ValidationResult("Receitas não podem ser menor que zero.", new[] { nameof(Valor) }));
            }
            else if (TipoFinanca == TipoFinancaEnum.Debito && Valor > 0)
            {
                errors.Add(new ValidationResult("Despesas não podem ser maior que zero.", new[] { nameof(Valor) }));
            }

            return errors;
        }
    }
}
