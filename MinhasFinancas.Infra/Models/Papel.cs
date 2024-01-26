using MinhasFinancas.Infra.Data.Models.Enums;
using System.Collections.Generic;

namespace MinhasFinancas.Infra.Models
{
    public class Papel : Entity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public TipoPapel TipoPapel { get; set; }
        public decimal CotacaoAtual { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        /* Relações EF */
        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<Dividendo> Dividendos { get; set; }
        public virtual ICollection<Segmento> Segmentos { get; set; }
    }
}