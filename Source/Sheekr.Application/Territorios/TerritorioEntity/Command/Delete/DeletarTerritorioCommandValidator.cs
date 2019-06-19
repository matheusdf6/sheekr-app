using FluentValidation;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class DeletarTerritorioCommandValidator : AbstractValidator<DeletarTerritorioCommand>
    {
        public DeletarTerritorioCommandValidator()
        {
            RuleFor(t => t.TerritorioId)
                .NotEmpty();
        }
    }
}
