using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetAllPublicadorQueryHandler : IRequestHandler<GetAllPublicadorQuery, List<PublicadorDetailModel>>
    {
        private readonly SheekrDbContext _db;

        public GetAllPublicadorQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<List<PublicadorDetailModel>> Handle(GetAllPublicadorQuery request, CancellationToken cancellationToken)
        {
            var publicadores = await _db.Publicadores
                .Include(p => p.Aluno)
                .Include(p => p.Dirigente)
                .Include(p => p.Orador)
                .ToListAsync();

            if (publicadores == null)
                throw new NenhumRegistroException(nameof(Publicador));

            var list = new List<PublicadorDetailModel>(); 
            foreach (var publicador in publicadores)
            {
                list.Add(new PublicadorDetailModel
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
                });
            }

            return list;
        }
    }


}
