using System;
using System.Collections.Generic;
using System.Text;
using Sheekr.Domain.Enum;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class AtualizarDesignacaoCommand : IRequest<RequestInfo>
    {
        public int DesignacaoId { get; set; }
        public int LicaoId { get; set; }
        public int AlunoPrincipalId { get; set; }
        public int? AlunoAjudanteId { get; set; }
        public DateTime Data { get; set; }
        public TipoDesignacaoEscola Tipo { get; set; }
        public LocalDesignacao Local { get; set; }
    }
}
