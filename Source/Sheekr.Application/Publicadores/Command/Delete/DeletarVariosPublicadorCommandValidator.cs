using FluentValidation;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarVariosPublicadorCommandValidator : AbstractValidator<DeletarVariosPublicadorCommand>
    {
        public DeletarVariosPublicadorCommandValidator()
        {
            RuleFor(p => p.PublicadorIds).NotEmpty();
        }
    }
}
