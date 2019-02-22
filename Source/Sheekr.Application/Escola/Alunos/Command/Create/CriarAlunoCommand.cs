using System;
using MediatR;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class CriarAlunoCommand : IRequest
    {
        public int AlunoId { get; set; }

        public int PublicadorId { get; set; }

        public bool FazLeitura { get; set; }

        public bool FazDemonstracao { get; set; }

        public bool FazDiscurso { get; set; }
    }
}
