using System.ComponentModel.DataAnnotations;

namespace BlazorAdminGastosDiarios.Model.Validation
{
    public class FinacaDataTransacaoValidator: ValidationAttribute
    {
        public int DiasNoFuturo { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime dataDeTransacao;

            if(DateTime.TryParse(value.ToString(), out dataDeTransacao))
            {
                if(dataDeTransacao == DateTime.MinValue)
                {
                    return new ValidationResult($"A data não deve ser vazia.", new[] {validationContext.MemberName});
                }else if(dataDeTransacao > DateTime.Now.AddDays(DiasNoFuturo))
                {
                    return new ValidationResult($"A data não deve ser maior que a data de hoje somada a  {DiasNoFuturo} dias.",
                     new[] { validationContext.MemberName });
                }

                return null;
            }

            return new ValidationResult("Data inválida", new[] { validationContext.MemberName });

           
        }
    }
}
