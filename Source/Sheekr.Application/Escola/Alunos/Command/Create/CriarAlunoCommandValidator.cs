using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Sheekr.Application.Escola.Alunos.Command
{ 
    public class CriarAlunoCommandValidator : AbstractValidator<CriarAlunoCommand>
    {
        public CriarAlunoCommandValidator()
        {
            RuleFor(a => a.AlunoId).NotEmpty();
            RuleFor(a => a.PublicadorId).NotEmpty();
            RuleFor(a => a.FazLeitura).NotNull();
            RuleFor(a => a.FazDemonstracao).NotNull();
            RuleFor(a => a.FazDiscurso).NotNull();
        }
    }
}
