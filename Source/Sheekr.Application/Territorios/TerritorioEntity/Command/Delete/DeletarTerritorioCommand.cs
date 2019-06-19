using MediatR;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class DeletarTerritorioCommand : IRequest<RequestInfo>
    {
        public int TerritorioId { get; set; }
    }
}
