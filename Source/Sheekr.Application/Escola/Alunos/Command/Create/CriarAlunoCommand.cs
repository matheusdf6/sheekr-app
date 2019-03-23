using System;
using MediatR;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    /// Comando para criar nova entidade "Aluno", dentro da pipeline MediatR   
    /// </summary>
    public class CriarAlunoCommand : IRequest<RequestInfo>
    {
        public int PublicadorId { get; set; }
        public bool FazLeitura { get; set; }
        public bool FazDemonstracao { get; set; }
        public bool FazDiscurso { get; set; }
    }
}
