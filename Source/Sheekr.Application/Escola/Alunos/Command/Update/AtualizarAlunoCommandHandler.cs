using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Alunos.Command
{
    public class AtualizarAlunoCommandHandler : IRequestHandler<AtualizarAlunoCommand>
    {
        private readonly SheekrDbContext _db;

        public AtualizarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(AtualizarAlunoCommand request, CancellationToken cancellationToken)
        {
            var sucess = await _db.Publicadores.FindAsync(request.PublicadorId);
            if (sucess == null)
                throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

            var aluno = await _db.Alunos.FindAsync(request.AlunoId);

            if (aluno == null)
                throw new NaoEncontradoException(nameof(Sheekr.Domain.Entities.Aluno), request.AlunoId);

            aluno.PublicadorId = request.PublicadorId;
            aluno.FazDemonstracao = request.FazDemonstracao;
            aluno.FazLeitura = request.FazLeitura;
            aluno.FazDiscurso = request.FazDiscurso;

            _db.Alunos.Update(aluno);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
