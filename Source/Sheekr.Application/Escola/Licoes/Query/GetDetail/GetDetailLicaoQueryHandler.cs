using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Sheekr.Application.Exceptions;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetDetailLicaoQueryHandler : IRequestHandler<GetDetailLicaoQuery, Licao>
    {
        private readonly SheekrDbContext _db;

        public GetDetailLicaoQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Licao> Handle(GetDetailLicaoQuery request, CancellationToken cancellationToken)
        {
            var licao = await _db.Licoes.FindAsync(request.Id);

            if (licao == null)
                throw new NaoEncontradoException(nameof(Licao), request.Id);

            return licao;
        }
    }

}
