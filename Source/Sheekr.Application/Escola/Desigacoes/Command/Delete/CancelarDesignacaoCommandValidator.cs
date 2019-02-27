using FluentValidation;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class CancelarDesignacaoCommandValidator : AbstractValidator<CancelarDesignacaoCommand>
    {
        public CancelarDesignacaoCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
