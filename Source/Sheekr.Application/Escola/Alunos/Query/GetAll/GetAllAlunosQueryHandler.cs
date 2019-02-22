using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sheekr.Data;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAllPublicadorQueryHandler : IRequestHandler<GetAllAlunosQuery, List<AlunoDetailsModel>>
    {
        private readonly SheekrDbContext _db;

        public GetAllPublicadorQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<List<AlunoDetailsModel>> Handle(GetAllAlunosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await _db.Alunos
                .Include(a => a.DadosPublicador)
                .ToListAsync();

            if (alunos == null)
                throw new NenhumRegistroException(nameof(Aluno));

            var list = new List<AlunoDetailsModel>();
            foreach(var aluno in alunos)
            {
                list.Add(new AlunoDetailsModel
                {
                    AlunoId = aluno.AlunoId,
                    NomePublicador = aluno.DadosPublicador.NomeCompleto,
                    FazDemonstracao = aluno.FazDemonstracao,
                    FazDiscurso = aluno.FazDiscurso,
                    FazLeitura = aluno.FazLeitura
                });
            }

            return list;
        }
    }


}
