using MediatR;
using System;
using System.Text;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class DeletarLicaoCommand : IRequest<RequestInfo>
    {
        public int Id { get; set; }
    }
}
