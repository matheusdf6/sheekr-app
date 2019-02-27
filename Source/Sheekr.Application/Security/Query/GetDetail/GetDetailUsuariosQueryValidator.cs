using FluentValidation;

namespace Sheekr.Application.Security.Query
{
    public class GetDetailUsuariosQueryValidator : AbstractValidator<GetDetailUsuariosQuery>
    {
        public GetDetailUsuariosQueryValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
        }
    }
}
