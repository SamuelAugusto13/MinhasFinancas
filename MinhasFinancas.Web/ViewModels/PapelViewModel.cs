using MinhasFinancas.Infra.Data.Models.Enums;
using MinhasFinancas.Infra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Web.ViewModels
{
    public class PapelViewModel
    {
        public PapelViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tipo")]
        public TipoPapel TipoPapel { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [DisplayName("Cotação atual")]
        public double CotacaoAtual { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        public virtual IEnumerable<TransacaoViewModel> Transacaos { get; set; }
        public virtual IEnumerable<DividendoViewModel> Dividendos { get; set; }
        public virtual IEnumerable<SegmentoViewModel> Segmentos { get; set; }

        /// <summary>
        /// Propiedades fora classe
        /// </summary>

        public int QuantidadeTotal { get; set; }
    }
}