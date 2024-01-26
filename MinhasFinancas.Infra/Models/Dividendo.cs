using MinhasFinancas.Infra;
using System;

namespace MinhasFinancas.Infra.Models
{
    public class Dividendo : Entity
    {
        public Guid PapelId { get; set; }
        public double ValorRecebido { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        /* Relações EF */
        public virtual Papel Papel { get; set; }
    }
}