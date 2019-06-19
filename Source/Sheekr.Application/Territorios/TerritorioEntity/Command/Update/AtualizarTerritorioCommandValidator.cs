using FluentValidation;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class AtualizarTerritorioCommandValidator : AbstractValidator<AtualizarTerritorioCommand>
    {
        public AtualizarTerritorioCommandValidator()
        {
            RuleFor(t => t.TerritorioId)
                .NotEmpty();

            RuleFor(t => t.Descricao)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.Local)
                .IsInEnum();

            RuleFor(t => t.UrlImagem)
                .MaximumLength(100);
        }
    }

}
