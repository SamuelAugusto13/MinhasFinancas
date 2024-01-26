using MinhasFinancas.Infra.Data.Models.Enums;
using MinhasFinancas.Infra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Web.ViewModels
{
    public class TransacaoViewModel
    {
        public TransacaoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public TipoPapel TipoPapel { get; set; }
        public decimal CotacaoAtual { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<TransacaoViewModel> Transacoes { get; set; }
        public virtual IEnumerable<DividendoViewModel> Dividendos { get; set; }
        public virtual IEnumerable<SegmentoViewModel> Segmentos { get; set; }

        /// <summary>
        /// Propiedades fora classe
        /// </summary>
        public virtual IEnumerable<PapelViewModel> Papeis { get; set; }
    }
}