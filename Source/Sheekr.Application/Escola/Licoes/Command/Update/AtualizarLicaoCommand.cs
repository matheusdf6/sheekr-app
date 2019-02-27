using MediatR;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class AtualizarLicaoCommand : IRequest<RequestInfo>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}
