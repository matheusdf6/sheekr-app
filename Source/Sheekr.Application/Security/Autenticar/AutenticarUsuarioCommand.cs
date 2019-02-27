using MediatR;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Security
{
    public class AutenticarUsuarioCommand : IRequest<RequestInfo<UsuarioDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
