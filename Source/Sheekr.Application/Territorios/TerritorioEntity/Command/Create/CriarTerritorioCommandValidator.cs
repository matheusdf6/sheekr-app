using FluentValidation;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class CriarTerritorioCommandValidator : AbstractValidator<CriarTerritorioCommand>
    {
        public CriarTerritorioCommandValidator()
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