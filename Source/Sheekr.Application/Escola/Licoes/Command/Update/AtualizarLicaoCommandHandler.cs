using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class AtualizarLicaoCommandHandler : IRequestHandler<AtualizarLicaoCommand>
    {
        private readonly SheekrDbContext _db;

        public AtualizarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
        }

        public async Task<Unit> Handle(AtualizarLicaoCommand request, CancellationToken cancellationToken)
        {
            var licao = _db.Licoes.Find(request.Id);

            if (licao == null || licao.LicaoId != request.Id)
                throw new NaoEncontradoException(nameof(Licao), request.Id);

            licao.LicaoId = request.Id;
            licao.TituloLicao = request.Titulo;

            _db.Licoes.Update(licao);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
