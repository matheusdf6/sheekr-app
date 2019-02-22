using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sheekr.Application.Publicadores.Command
{
    public class CriarPublicadorCommandValidator : AbstractValidator<CriarPublicadorCommand>
    {
        public CriarPublicadorCommandValidator()
        {
            RuleFor(pub => pub.PublicadorId).NotEmpty();
            RuleFor(pub => pub.PrimeiroNome).NotNull().NotEmpty()
                .WithMessage("O campo 'Primeiro Nome' é nulo ou está vazio");
            RuleFor(pub => pub.UltimoNome).NotNull().NotEmpty()
                .WithMessage("O campo 'Ultimo Nome' é nulo ou está vazio");
            RuleFor(pub => pub.Privilegio).IsInEnum()
                .WithMessage("O campo 'Privilegio' não tem um valor permitido dentro da enumeração");
            RuleFor(pub => pub.Sexo).IsInEnum()
                .WithMessage("O campo 'Sexo' não tem um valor permitido dentro da enumeração");
            RuleFor(pub => pub.Email).Custom((email, context) =>
            {
                if (!String.IsNullOrEmpty(email))
                {
                    var attr = new EmailAddressAttribute();
                    var result = attr.IsValid(email);
                    if (!result)
                        context.AddFailure("O campo 'Email' não é um endereço de e-mail válido");
                }
            });
            RuleFor(pub => pub.Telefone).Custom((fone, context) =>
            {
                if (!String.IsNullOrEmpty(fone))
                    if (fone.Length < 8 || fone.Length > 11)
                        context.AddFailure("O campo 'Telefone' não está dentro do intervalo de 8 a 11 dígitos");
            });
        }
    }
}
