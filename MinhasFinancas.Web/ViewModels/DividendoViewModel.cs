using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Web.ViewModels
{
    public class DividendoViewModel
    {
        public DividendoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid PapelId { get; set; }
        public double ValorRecebido { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        /* Relações EF */
        public virtual PapelViewModel Papel { get; set; }

        /// <summary>
        /// Propiedades fora classe
        /// </summary>
        public virtual IEnumerable<PapelViewModel> Papeis { get; set; }


    }
}