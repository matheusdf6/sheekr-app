using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetDetailPublicadorQueryHandler : IRequestHandler<GetDetailPublicadorQuery, PublicadorDetailModel>
    {
        private readonly SheekrDbContext _db;

        public GetDetailPublicadorQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<PublicadorDetailModel> Handle(GetDetailPublicadorQuery request, CancellationToken cancellationToken)
        {
            var publicador = await _db.Publicadores
                .Include(p => p.Aluno)
                .Include(p => p.Dirigente)
                .Include(p => p.Orador)
                .FirstAsync(p => p.PublicadorId == request.PublicadorId);

            if (publicador == null)
                throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

            return new PublicadorDetailModel
            {
                PublicadorId = publicador.PublicadorId,
                NomeCompleto = publicador.NomeCompleto,
                Sexo = publicador.Sexo.ToString(),
                Privilegio = publicador.Privilegio.ToString(),
                Telefone = publicador.Telefone,
                Email = publicador.Email,
                IsAluno = (publicador.Aluno != null),
                IsOrador = (publicador.Orador != null),
                IsDirigente = (publicador.Dirigente != null)
            };
        }
    }
}
