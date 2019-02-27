using System.Collections.Generic;
using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using System;
using System.Data.Common;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetAllLicoesQueryHandler : IRequestHandler<GetAllLicoesQuery, RequestInfo<LicaoListViewModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<LicaoListViewModel> _info;

        public GetAllLicoesQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<LicaoListViewModel>();
        }

        public async Task<RequestInfo<LicaoListViewModel>> Handle(GetAllLicoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new LicaoListViewModel
                {
                    Licoes = await _db.Licoes.ToListAsync()
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
