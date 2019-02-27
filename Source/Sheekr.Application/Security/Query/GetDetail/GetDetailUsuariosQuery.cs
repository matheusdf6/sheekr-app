using MediatR;

namespace Sheekr.Application.Security.Query
{
    public class GetDetailUsuariosQuery : IRequest<RequestInfo<UsuarioDetailModel>>
    {
        public int Id { get; set; }
    }
}
