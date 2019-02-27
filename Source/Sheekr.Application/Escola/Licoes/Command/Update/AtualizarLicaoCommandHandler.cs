using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class AtualizarLicaoCommandHandler : IRequestHandler<AtualizarLicaoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public AtualizarLicaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(AtualizarLicaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licao = _db.Licoes.Find(request.Id);

                if (licao == null || licao.LicaoId != request.Id)
                    throw new NaoEncontradoException(nameof(Licao), request.Id);

                licao.LicaoId = request.Id;
                licao.TituloLicao = request.Titulo.Trim();

                _db.Licoes.Update(licao);
                await _db.SaveChangesAsync(cancellationToken);

                _info.Sucess();
            }
            catch(NaoEncontradoException ex)
            {
                _info.AddFailure("Lição não encontrada", ex);
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
