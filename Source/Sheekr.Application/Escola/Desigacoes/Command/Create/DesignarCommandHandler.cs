using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class DesignarCommandHandler : IRequestHandler<DesignarCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public DesignarCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }


        public async Task<RequestInfo> Handle(DesignarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _db.Designacoes.Add(new Designacao()
                {
                    LicaoId = request.LicaoId,
                    AlunoPrincipalId = request.AlunoPrincipalId,
                    AlunoAjudanteId = request.AlunoAjudanteId,
                    Data = request.Data,
                    Tipo = request.Tipo,
                    Local = request.Local
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
