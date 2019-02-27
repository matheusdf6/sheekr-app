using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    ///  Classe que valida os dados informados na classe "DeletarAlunoCommand"
    /// </summary>
    public class DeletarAlunoCommandValidator : AbstractValidator<DeletarAlunoCommand>
    {
        public DeletarAlunoCommandValidator()
        {
            RuleFor(a => a.AlunoId).NotEmpty();
        }
    }
}
