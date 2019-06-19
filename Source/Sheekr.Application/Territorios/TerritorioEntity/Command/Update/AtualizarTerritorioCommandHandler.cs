using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class AtualizarTerritorioCommandHandler : IRequestHandler<AtualizarTerritorioCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public AtualizarTerritorioCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(AtualizarTerritorioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var territorio = _db.Territorios.Find(request.TerritorioId);

                if (territorio == null)
                    throw new NaoEncontradoException(nameof(Territorio), request.TerritorioId);

                territorio.Descricao = request.Descricao;
                territorio.Local = request.Local;
                territorio.UrlImagem = request.UrlImagem;

                _db.Territorios.Update(territorio);
                await _db.SaveChangesAsync(cancellationToken);
                _info.AddExtra("id", territorio.TerritorioId);
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
