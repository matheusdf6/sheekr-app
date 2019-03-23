using MediatR;
using Sheekr.Domain.Enum;
using System;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class DesignarCommand : IRequest<RequestInfo>
    {
        public int LicaoId { get; set; }
        public int AlunoPrincipalId { get; set; }
        public int? AlunoAjudanteId { get; set; }
        public DateTime Data { get; set; }
        public TipoDesignacaoEscola Tipo { get; set; }
        public LocalDesignacao Local { get; set; }
    }
}
