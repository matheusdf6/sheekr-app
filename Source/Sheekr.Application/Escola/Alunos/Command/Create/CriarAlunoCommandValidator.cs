using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    /// Classe que valida os dados informados na classe "CriarAlunoCommand"
    /// </summary>
    public class CriarAlunoCommandValidator : AbstractValidator<CriarAlunoCommand>
    {
        public CriarAlunoCommandValidator()
        {
            RuleFor(a => a.PublicadorId).NotEmpty();
            RuleFor(a => a.FazLeitura).NotNull();
            RuleFor(a => a.FazDemonstracao).NotNull();
            RuleFor(a => a.FazDiscurso).NotNull();
        }
    }
}
