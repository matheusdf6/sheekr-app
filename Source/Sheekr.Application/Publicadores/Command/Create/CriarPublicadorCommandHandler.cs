using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class CriarPublicadorCommandHandler : IRequestHandler<CriarPublicadorCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public CriarPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(CriarPublicadorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _db.Publicadores.Add(new Publicador()
                {
                    PrimeiroNome = request.PrimeiroNome.Trim(),
                    UltimoNome = request.UltimoNome.Trim(),
                    Email = (request.Email != null) ? request.Email.Trim() : null,
                    Telefone = (request.Telefone != null) ? request.Telefone.Trim() : null,
                    Sexo = request.Sexo,
                    Privilegio = request.Privilegio
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
