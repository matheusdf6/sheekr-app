using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAlunoDetailsQueryValidator : AbstractValidator<GetAlunoDetailsQuery>
    {
        public GetAlunoDetailsQueryValidator()
        {
            RuleFor(a => a.AlunoId).NotEmpty();
        }
    }
}
