using MediatR;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class CancelarDesignacaoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
