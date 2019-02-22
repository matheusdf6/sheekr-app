using Sheekr.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Domain.Entities;
using Sheekr.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetDetailDesignacaoQueryHandle
        : IRequestHandler<GetDetailDesignacaoQuery, DesignacaoDetailModel>
    {
        private readonly SheekrDbContext _db;

        public GetDetailDesignacaoQueryHandle(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<DesignacaoDetailModel> Handle(GetDetailDesignacaoQuery request, CancellationToken cancellationToken)
        {
            var designacao = await _db.Designacoes
                .Include(q => q.AlunoPrincipal)
                        .ThenInclude(a => a.DadosPublicador)
                .Include(q => q.AlunoAjudante)
                        .ThenInclude(a => a.DadosPublicador)
                .FirstAsync(q => q.DesignacaoId == request.Id);              

            if (designacao == null || designacao.DesignacaoId != request.Id)
                throw new NaoEncontradoException(nameof(Designacao), request.Id);

            return new DesignacaoDetailModel
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
            };
        }
    }
}
