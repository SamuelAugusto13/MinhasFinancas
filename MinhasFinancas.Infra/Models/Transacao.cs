using MinhasFinancas.Infra.Data.Models.Enums;
using System;

namespace MinhasFinancas.Infra.Models
{
    public class Transacao : Entity
    {
        public Guid PapelId { get; set; }
        public double ValorUnt { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        /* Relações EF */
        public virtual Papel Papel { get; set; }
    }
}