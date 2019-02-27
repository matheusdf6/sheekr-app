using System;
using Sheekr.Domain.Entities.Enum;
using FluentValidation;

namespace Sheekr.Application.Security
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.PrimeiroNome).NotEmpty().MaximumLength(20);
            RuleFor(u => u.UltimoNome).NotEmpty().MaximumLength(20);
            RuleFor(u => u.UserName).NotEmpty().MinimumLength(8).MaximumLength(30);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8).MaximumLength(30);
            RuleFor(u => u.Role).Custom((role, context) =>
            {
                if (role.HasValue && !Enum.IsDefined(typeof(Role), role))
                    context.AddFailure($"A 'Role' fornecida não existe");
            });
        }
    }
}
