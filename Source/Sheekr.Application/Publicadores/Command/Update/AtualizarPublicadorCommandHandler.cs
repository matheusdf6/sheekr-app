using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class AtualizarPublicadorCommandHandler : IRequestHandler<AtualizarPublicadorCommand>
    {
        private readonly SheekrDbContext _db;

        public AtualizarPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(AtualizarPublicadorCommand request, CancellationToken cancellationToken)
        {
            var publicador = await _db.Publicadores.FindAsync(request.PublicadorId);

            if (publicador == null)
                throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

            publicador.PrimeiroNome = request.PrimeiroNome;
            publicador.UltimoNome = request.UltimoNome;
            publicador.Email = request.Email;
            publicador.Telefone = request.Telefone;
            publicador.Sexo = request.Sexo;
            publicador.Privilegio = request.Privilegio;

            _db.Publicadores.Update(publicador);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
