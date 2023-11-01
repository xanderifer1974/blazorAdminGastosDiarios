using BlazorAdminGastosDiarios.Model.Enum;

namespace BlazorAdminGastosDiarios.Model
{
    public class Financa
    {
        public int IdFinaca { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; } = null;
        public TipoFinancaEnum TipoFinanca { get; set; }
        public DateTime DataFinanca { get; set; }

    }
}
