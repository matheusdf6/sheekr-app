using FluentValidation;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class DeletarLicaoCommandValidator : AbstractValidator<DeletarLicaoCommand>
    {
        public DeletarLicaoCommandValidator()
        {
            RuleFor(l => l.Id).NotEmpty().InclusiveBetween(1, 100);
        }
    }
}
