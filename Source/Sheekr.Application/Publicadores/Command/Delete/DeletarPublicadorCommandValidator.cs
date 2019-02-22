using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarPublicadorCommandValidator : AbstractValidator<DeletarPublicadorCommand>
    {
        public DeletarPublicadorCommandValidator()
        {
            RuleFor(p => p.PublicadorId).NotEmpty();
        }
    }
}
