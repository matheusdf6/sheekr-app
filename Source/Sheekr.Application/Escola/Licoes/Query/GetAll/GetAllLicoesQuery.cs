using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetAllLicoesQuery : IRequest<List<Licao>>
    {
    }
}
