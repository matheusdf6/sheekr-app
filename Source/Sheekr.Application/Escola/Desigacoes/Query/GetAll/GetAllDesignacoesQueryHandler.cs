using System.Collections.Generic;
using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using System;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetAllDesignacoesQueryHandler
        : IRequestHandler<GetAllDesignacoesQuery, RequestInfo<DesignacaoListViewModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<DesignacaoListViewModel> _info;

        public GetAllDesignacoesQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<DesignacaoListViewModel>();
        }

        public async Task<RequestInfo<DesignacaoListViewModel>> Handle(GetAllDesignacoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new DesignacaoListViewModel
                {
                    Designacoes = await _db.Designacoes
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
                            Data = d.Data.ToShortDateString(),
                            Licao = d.LicaoId,
                            Local = d.Local.ToString(),
                            Tipo = d.Tipo.ToString()
                        })
                        .ToListAsync()
                };

                _info.Sucess();
                _info.AddResponde(vm);
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
