using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class DeletarVariosPublicadorCommandHandler : IRequestHandler<DeletarVariosPublicadorCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public DeletarVariosPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(DeletarVariosPublicadorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publicadores = new List<Publicador>();

                foreach (var pubId in request.PublicadorIds)
                {
                    var publicador = _db.Publicadores.Find(pubId);
                    if (publicador == null)
                        throw new NaoEncontradoException(nameof(Publicador), pubId);
                    publicadores.Add(publicador);
                }

                _db.Publicadores.RemoveRange(publicadores);

                await _db.SaveChangesAsync(cancellationToken);
                _info.Sucess();
            }
            catch (NaoEncontradoException ex)
            {
                _info.AddFailure("Publicador não encontrada", ex);
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
