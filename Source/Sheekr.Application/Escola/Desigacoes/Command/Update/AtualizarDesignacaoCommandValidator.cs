using System;
using FluentValidation;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class AtualizarDesignacaoCommandValidator : AbstractValidator<AtualizarDesignacaoCommand>
    {
        public AtualizarDesignacaoCommandValidator()
        {
            RuleFor(d => d.DesignacaoId).NotEmpty();
            RuleFor(d => d.AlunoPrincipalId).NotNull();
            RuleFor(d => d.LicaoId).InclusiveBetween(1, 20);
            RuleFor(d => d.Local).IsInEnum();
            RuleFor(d => d.Tipo).IsInEnum();
            RuleFor(d => d.Data).GreaterThan(new DateTime(2019, 1, 1));
        }
    }
}
