using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class AtualizarAlunoCommandValidator : AbstractValidator<AtualizarAlunoCommand>
    {
        public AtualizarAlunoCommandValidator()
        {
            RuleFor(a => a.AlunoId).NotEmpty();
            RuleFor(a => a.PublicadorId).NotEmpty();
            RuleFor(a => a.FazLeitura).NotNull();
            RuleFor(a => a.FazDemonstracao).NotNull();
            RuleFor(a => a.FazDiscurso).NotNull();
        }
    }
}
