using MediatR;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAllAlunosQuery : IRequest<RequestInfo<AlunoListViewModel>>
    {
        
    }


}
