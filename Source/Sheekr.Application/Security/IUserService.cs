using System.Threading.Tasks;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Entities.Enum;

namespace Sheekr.Application.Security
{
    public interface IUserService
    {
        Task<UsuarioDto> AuthenticateAsync(string username, string password);
        Task<bool> CreateUserAsync(Usuario user, string password, Role role);
    }
}
