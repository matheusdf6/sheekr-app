using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Data;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class CancelarDesignacaoCommandHandler : IRequestHandler<CancelarDesignacaoCommand>
    {
        private readonly SheekrDbContext _db;

        public CancelarDesignacaoCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(CancelarDesignacaoCommand request, CancellationToken cancellationToken)
        {
            var designacao = _db.Designacoes.Find(request.Id);

            if (designacao == null)
                throw new NaoEncontradoException(nameof(Designacao), request.Id);

            _db.Designacoes.Remove(designacao);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
