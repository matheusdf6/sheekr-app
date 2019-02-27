using MediatR;
using Sheekr.Domain.Entities.Enum;

namespace Sheekr.Application.Security
{
    public class CreateUserCommand : IRequest<RequestInfo>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
