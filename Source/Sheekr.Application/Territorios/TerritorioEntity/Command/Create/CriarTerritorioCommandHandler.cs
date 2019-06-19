using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Territorios.TerritorioEntity.Command
{
    public class CriarTerritorioCommandHandler : IRequestHandler<CriarTerritorioCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public CriarTerritorioCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(CriarTerritorioCommand request, CancellationToken cancellationToken)
        {
            try {
                
                var territorio = new Territorio
                {
                    TerritorioId = request.TerritorioId,
                    Local = request.Local,
                    Descricao = request.Descricao,
                    UrlImagem = request.UrlImagem
                };

                _db.Territorios.Add(territorio);
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