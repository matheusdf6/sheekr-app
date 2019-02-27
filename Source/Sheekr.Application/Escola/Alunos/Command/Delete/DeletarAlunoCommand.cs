using MediatR;
using Sheekr.Domain.Entities;
using System;
using System.Text;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    ///    Comando para excluir uma entidade "Aluno", dentro da pipeline MediatR 
    /// </summary>
    public class DeletarAlunoCommand : IRequest<RequestInfo>
    {
        public int AlunoId { get; set; }
    }
}
