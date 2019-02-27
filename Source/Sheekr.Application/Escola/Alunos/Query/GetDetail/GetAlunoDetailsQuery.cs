using MediatR;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAlunoDetailsQuery : IRequest<RequestInfo<AlunoDetailsModel>>
    {
        public int AlunoId { get; set; }
    }
}
