using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class DeletarLicaoCommandHandler : IRequestHandler<DeletarLicaoCommand>
    {
        private readonly SheekrDbContext _db;

        public DeletarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
        }

        public async Task<Unit> Handle(DeletarLicaoCommand request, CancellationToken cancellationToken)
        {
            var licao = _db.Licoes.Find(request.Id);

            if (licao == null)
                throw new NaoEncontradoException(nameof(Licao), request.Id);

            _db.Licoes.Remove(licao);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
