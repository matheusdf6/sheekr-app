using System.Collections.Generic;
using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetAllDesignacoesQueryHandler
        : IRequestHandler<GetAllDesignacoesQuery, List<DesignacaoDetailModel>>
    {
        private readonly SheekrDbContext _db;

        public GetAllDesignacoesQueryHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<List<DesignacaoDetailModel>> Handle(GetAllDesignacoesQuery request, CancellationToken cancellationToken)
        {
            // TODO: Refatorar!
            var qtde = request.Quantity ?? 0;
            var designacoes = new List<Designacao>();
            if (qtde == 0)
                designacoes = await _db.Designacoes
                    .Include(q => q.AlunoPrincipal)
                        .ThenInclude(a => a.DadosPublicador)
                    .Include(q => q.AlunoAjudante)
                        .ThenInclude(a => a.DadosPublicador)
                    .ToListAsync();
            else
                designacoes = await _db.Designacoes
                    .Include(q => q.AlunoPrincipal)
                        .ThenInclude(a => a.DadosPublicador)
                    .Include(q => q.AlunoAjudante)
                        .ThenInclude(a => a.DadosPublicador)
                    .Take(qtde)
                    .ToListAsync();

            if (designacoes == null || designacoes.Count == 0)
                throw new NenhumRegistroException(nameof(Desigacoes));

            var list = new List<DesignacaoDetailModel>();
            foreach(var designacao in designacoes)
            {
                list.Add(new DesignacaoDetailModel
                {
                    Id = designacao.DesignacaoId,
                    NomePrincipal = designacao.AlunoPrincipal.DadosPublicador.NomeCompleto,
                    NomeAjudante = (designacao.AlunoAjudante != null)
                                    ? designacao.AlunoAjudante.DadosPublicador.NomeCompleto
                                    : " ",
                    Licao = designacao.LicaoId,
                    Data = designacao.Data.ToShortDateString(),
                    Local = designacao.Local.ToString(),
                    Tipo = designacao.Tipo.ToString()
                });
            }

            return list;
        }
    }
}
