using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Data;
using Sheekr.Application.Exceptions;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class CriarAlunoCommandHandler : IRequestHandler<CriarAlunoCommand, MediatR.Unit>
    {
        private readonly SheekrDbContext _db;

        public CriarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
        {
            var sucess = await _db.Publicadores.FindAsync(request.PublicadorId);
            if (sucess == null)
                throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

            var entity = new Aluno()
            {
                AlunoId = request.AlunoId,
                PublicadorId = request.PublicadorId,
                FazLeitura = request.FazLeitura,
                FazDemonstracao = request.FazDemonstracao,
                FazDiscurso = request.FazDiscurso
            };

            _db.Alunos.Add(entity);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
