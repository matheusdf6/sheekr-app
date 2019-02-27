using FluentValidation;

namespace Sheekr.Application.Security
{
    public class AutenticarUsuarioCommandValidator : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioCommandValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().MinimumLength(8).MaximumLength(30);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8).MaximumLength(30);
        }
    }
}
