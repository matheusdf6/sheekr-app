using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class DeletarAlunoCommandValidator : AbstractValidator<DeletarAlunoCommand>
    {
        public DeletarAlunoCommandValidator()
        {
            RuleFor(a => a.AlunoId).NotEmpty();
        }
    }
}
