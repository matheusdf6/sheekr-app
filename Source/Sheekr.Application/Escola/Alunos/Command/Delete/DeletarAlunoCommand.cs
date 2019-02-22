using MediatR;
using Sheekr.Domain.Entities;
using System;
using System.Text;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class DeletarAlunoCommand : IRequest
    {
        public int AlunoId { get; set; }
    }
}
