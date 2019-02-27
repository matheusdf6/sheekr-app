using MediatR;

namespace Sheekr.Application.Security.Query
{
    public class GetAllUsuariosQuery : IRequest<RequestInfo<UsuarioListViewModel>> 
    {
    }
}
