using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Service.Papel
{
    public class PapelValidation : AbstractValidator<Infra.Models.Papel>
    {
        public PapelValidation()
        {

            RuleFor(p => p.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio")
                .Length(5, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.TipoPapel)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio");

            RuleFor(p => p.CotacaoAtual)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio")
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(d => d.Ativo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio");

            //When(p => p.TipoPapel == TipoPapel.BDR, () => {});
        }
    }
}