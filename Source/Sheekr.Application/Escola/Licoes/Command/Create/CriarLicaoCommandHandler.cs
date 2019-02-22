using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class CriarLicaoCommandHandler : IRequestHandler<CriarLicaoCommand>
    {
        private readonly SheekrDbContext _db;

        public CriarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(CriarLicaoCommand request, CancellationToken cancellationToken)
        {
            var licao = new Licao()
            {
                LicaoId = request.Id,
                TituloLicao = request.Titulo
            };

            _db.Licoes.Add(licao);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;            
        }
    }
}
