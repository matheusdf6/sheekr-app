using System;
using System.Data.Common;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class DeletarTerritorioCommandHandler : IRequestHandler<DeletarTerritorioCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public DeletarTerritorioCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            _info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(DeletarTerritorioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var territorio = _db.Territorios.Find(request.TerritorioId);

                if (territorio == null)
                    throw new NaoEncontradoException(nameof(Territorio), request.TerritorioId);

                _db.Territorios.Remove(territorio);
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
