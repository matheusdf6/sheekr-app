using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class CriarLicaoCommandHandler : IRequestHandler<CriarLicaoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public CriarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(CriarLicaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _db.Licoes.Add(new Licao()
                {
                    LicaoId = request.Id,
                    TituloLicao = request.Titulo.Trim()
                });

                await _db.SaveChangesAsync(cancellationToken);
                _info.Sucess();
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
