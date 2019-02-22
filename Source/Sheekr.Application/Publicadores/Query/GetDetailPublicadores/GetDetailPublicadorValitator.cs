using FluentValidation;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetDetailPublicadorValitator : AbstractValidator<GetDetailPublicadorQuery>
    {
        public GetDetailPublicadorValitator()
        {
            RuleFor(q => q.PublicadorId).NotNull();
        }
    }
}
