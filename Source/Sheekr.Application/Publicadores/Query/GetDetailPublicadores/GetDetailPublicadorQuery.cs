using MediatR;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetDetailPublicadorQuery : IRequest<RequestInfo<PublicadorDetailModel>>
    {
        public int PublicadorId { get; set; }
    }
}
