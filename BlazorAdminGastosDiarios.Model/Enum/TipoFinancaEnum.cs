using System.ComponentModel;

namespace BlazorAdminGastosDiarios.Model.Enum
{
    public enum TipoFinancaEnum
    {
        [Description("Débito")]
        Debito = 0,
        [Description("Crédito")]
        Credito = 1
    }
}
