using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class CriarPublicadorCommandHandler : IRequestHandler<CriarPublicadorCommand>
    {
        private readonly SheekrDbContext _db;

        public CriarPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(CriarPublicadorCommand request, CancellationToken cancellationToken)
        {
            var publicador = new Publicador()
            {
                PublicadorId = request.PublicadorId,
                PrimeiroNome = request.PrimeiroNome,
                UltimoNome = request.UltimoNome,
                Email = request.Email,
                Telefone = request.Telefone,
                Sexo = request.Sexo,
                Privilegio = request.Privilegio
            };

            _db.Publicadores.Add(publicador);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
