using MediatR;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetDetailLicaoQuery : IRequest<RequestInfo<Licao>>
    {
        public int Id { get; set; }
    }

}
