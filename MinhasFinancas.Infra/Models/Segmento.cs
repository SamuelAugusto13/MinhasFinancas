using System.Collections.Generic;

namespace MinhasFinancas.Infra.Models
{
    public class Segmento : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }


        public virtual ICollection<Papel> Papeis { get; set; }
    }
}