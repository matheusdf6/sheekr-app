using MediatR;
using Sheekr.Domain.Entities;
using System.Collections.Generic;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAllAlunosQuery : IRequest<List<AlunoDetailsModel>>
    {
        
    }


}
