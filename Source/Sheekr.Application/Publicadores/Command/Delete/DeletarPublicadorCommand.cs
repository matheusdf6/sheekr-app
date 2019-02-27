using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Enum;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarPublicadorCommand : IRequest<RequestInfo>
    {
        public int PublicadorId { get; set; }
    }
}
