using MediatR;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetDetailPublicadorQuery : IRequest<PublicadorDetailModel>
    {
        public int PublicadorId { get; set; }
    }
}
