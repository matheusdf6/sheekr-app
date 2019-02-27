using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    ///  Comando para atualizar uma entidade "Aluno", dentro da pipeline MediatR 
    /// </summary>
    public class AtualizarAlunoCommand : IRequest<RequestInfo>
    {
        public int AlunoId { get; set; }
        public int PublicadorId { get; set; }
        public bool FazLeitura { get; set; }
        public bool FazDemonstracao { get; set; }
        public bool FazDiscurso { get; set; }
    }
}
