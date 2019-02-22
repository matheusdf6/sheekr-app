using System.Collections.Generic;
using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetAllLicoesQueryHandler : IRequestHandler<GetAllLicoesQuery, List<Licao>>
    {
        private readonly SheekrDbContext _db;

        public GetAllLicoesQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<List<Licao>> Handle(GetAllLicoesQuery request, CancellationToken cancellationToken)
        {
            var licoes = await _db.Licoes.ToListAsync();

            if (licoes == null || licoes.Count == 0)
                throw new NenhumRegistroException(nameof(Licao));

            return licoes;
        }
    }

}
