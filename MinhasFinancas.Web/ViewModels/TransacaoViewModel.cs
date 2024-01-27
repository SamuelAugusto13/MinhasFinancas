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
    public class TransacaoViewModel
    {
        public TransacaoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Papel")]
        public Guid PapelId { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [DisplayName("Valor Unitário")]
        public double ValorUnt { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tipo")]
        public TipoTransacao TipoTransacao { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        /* Relações EF */
        public virtual PapelViewModel Papel { get; set; }

        /// <summary>
        /// Propiedades fora classe
        /// </summary>
        public virtual IEnumerable<PapelViewModel> Papeis { get; set; }
    }
}