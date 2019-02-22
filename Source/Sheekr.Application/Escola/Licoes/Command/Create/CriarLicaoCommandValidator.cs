using FluentValidation;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class CriarLicaoCommandValidator : AbstractValidator<CriarLicaoCommand>
    {
        public CriarLicaoCommandValidator()
        {
            RuleFor(l => l.Id).NotEmpty().InclusiveBetween(1, 100);
            RuleFor(l => l.Titulo).NotEmpty().MaximumLength(100);
        }
    }
}
