using FluentValidation;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetDetailLicaoQueryValidator : AbstractValidator<GetDetailLicaoQuery>
    {
        public GetDetailLicaoQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty();
        }
    }

}
