using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class DeletarAlunoCommandHandler : IRequestHandler<DeletarAlunoCommand>
    {
        private readonly SheekrDbContext _db;

        public DeletarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeletarAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _db.Alunos.FindAsync(request.AlunoId);

            if (aluno == null)
                throw new NaoEncontradoException(nameof(Sheekr.Domain.Entities.Aluno), request.AlunoId);

            _db.Alunos.Remove(aluno);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
