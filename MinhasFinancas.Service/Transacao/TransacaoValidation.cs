using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Service.Transacao
{
    public class TransacaoValidation : AbstractValidator<Infra.Models.Transacao>
    {
        public TransacaoValidation()
        {

            RuleFor(t => t.ValorUnt)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(t => t.Quantidade)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(t => t.Data)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio"); //Validar depois

            RuleFor(t => t.TipoTransacao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio");

            RuleFor(t => t.Ativo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio");
        }
    }
}