using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class DeletarLicaoCommandHandler : IRequestHandler<DeletarLicaoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public DeletarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(DeletarLicaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licao = _db.Licoes.Find(request.Id);

                if (licao == null)
                    throw new NaoEncontradoException(nameof(Licao), request.Id);

                _db.Licoes.Remove(licao);

                await _db.SaveChangesAsync(cancellationToken);
                _info.Sucess();
            }
            catch (DbException ex)
            {
                _info.AddFailure("Erro ocorrido ao salvar dados no banco de dados", ex);
            }
            catch (Exception ex)
            {
                _info.AddFailure($"Erro! Conferir descrição. ", ex);
            }

            return _info;
        }
    }
}
