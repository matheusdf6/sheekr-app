using Sheekr.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Domain.Entities;
using Sheekr.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Common;
using System;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetDetailDesignacaoQueryHandle
        : IRequestHandler<GetDetailDesignacaoQuery, RequestInfo<DesignacaoDetailModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<DesignacaoDetailModel> _info;

        public GetDetailDesignacaoQueryHandle(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<DesignacaoDetailModel>();
        }

        public async Task<RequestInfo<DesignacaoDetailModel>> Handle(GetDetailDesignacaoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var designacao = await _db.Designacoes
                    .Include(q => q.AlunoPrincipal)
                            .ThenInclude(a => a.DadosPublicador)
                    .Include(q => q.AlunoAjudante)
                            .ThenInclude(a => a.DadosPublicador)
                    .Select(d => new DesignacaoDetailModel
                    {
                        Id = d.DesignacaoId,
                        NomePrincipal = d.AlunoPrincipal.DadosPublicador.NomeCompleto,
                        NomeAjudante = (d.AlunoAjudante != null)
                                        ? d.AlunoAjudante.DadosPublicador.NomeCompleto
                                        : " ",
                        Licao = d.LicaoId,
                        Data = d.Data.ToShortDateString(),
                        Local = d.Local.ToString(),
                        Tipo = d.Tipo.ToString()
                    })
                    .FirstAsync(q => q.Id == request.Id);

                if (designacao == null || designacao.Id != request.Id)
                    throw new NaoEncontradoException(nameof(Designacao), request.Id);

                _info.Sucess();
                _info.AddResponde(designacao);
            }
            catch (NaoEncontradoException ex)
            {
                _info.AddFailure("Designacao não encontrado", ex);
            }
            catch (DbException ex)
            {
                _info.AddFailure("Erro ocorrido ao fazer conexão com banco de dados", ex);
            }
            catch (Exception ex)
            {
                _info.AddFailure($"Erro! Conferir descrição. ", ex);
            }

            return _info;
        }
    }
}
