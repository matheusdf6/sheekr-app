using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarPublicadorCommandHandler : IRequestHandler<DeletarPublicadorCommand>
    {
        private readonly SheekrDbContext _db;

        public DeletarPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(DeletarPublicadorCommand request, CancellationToken cancellationToken)
        {
            var publicador = _db.Publicadores.Find(request.PublicadorId);
            if (publicador == null)
                throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

            _db.Publicadores.Remove(publicador);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
