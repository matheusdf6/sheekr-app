using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAlunoDetailsQueryHandler : IRequestHandler<GetAlunoDetailsQuery, AlunoDetailsModel>
    {
        private readonly SheekrDbContext _db;

        public GetAlunoDetailsQueryHandler(SheekrDbContext db)
        {
            _db = db;
        }

        public async Task<AlunoDetailsModel> Handle(GetAlunoDetailsQuery request, CancellationToken cancellationToken)
        {
            var aluno = await _db.Alunos
                .Include(a => a.DadosPublicador)
                .SingleAsync(a => a.AlunoId == request.AlunoId);

            if (aluno == null)
                throw new NaoEncontradoException(nameof(Aluno), request.AlunoId);

            return new AlunoDetailsModel
            {
                AlunoId = aluno.AlunoId,
                NomePublicador = aluno.DadosPublicador.NomeCompleto,
                FazDemonstracao = aluno.FazDemonstracao,
                FazDiscurso = aluno.FazDiscurso,
                FazLeitura = aluno.FazLeitura
            };
        }
    }
}
