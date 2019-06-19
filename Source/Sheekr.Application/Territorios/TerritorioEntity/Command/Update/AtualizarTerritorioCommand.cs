using System.Reflection;
using MediatR;
using Sheekr.Domain.Enum;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class AtualizarTerritorioCommand : IRequest<RequestInfo>
    {
        public int TerritorioId { get; set; }
        public Local Local { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
    }

}
