using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Sheekr.Domain.Enum;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetAllDesignacoesQuery : IRequest<RequestInfo<DesignacaoListViewModel>>
    {
    }
}
