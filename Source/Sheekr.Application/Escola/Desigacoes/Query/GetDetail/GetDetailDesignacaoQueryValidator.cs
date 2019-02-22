using FluentValidation;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetDetailDesignacaoQueryValidator : AbstractValidator<GetDetailDesignacaoQuery>
    {
        public GetDetailDesignacaoQueryValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
