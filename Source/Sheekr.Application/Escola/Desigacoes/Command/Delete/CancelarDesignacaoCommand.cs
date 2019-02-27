using MediatR;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class CancelarDesignacaoCommand : IRequest<RequestInfo>
    {
        public int Id { get; set; }
    }
}
