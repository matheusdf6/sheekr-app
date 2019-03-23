using MediatR;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarVariosPublicadorCommand : IRequest<RequestInfo>
    {
        public int[] PublicadorIds { get; set; }
    }
}
