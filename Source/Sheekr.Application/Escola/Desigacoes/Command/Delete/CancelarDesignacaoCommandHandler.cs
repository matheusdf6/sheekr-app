using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Data;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Entities;
using System.Data.Common;
using System;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class CancelarDesignacaoCommandHandler : IRequestHandler<CancelarDesignacaoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public CancelarDesignacaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(CancelarDesignacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var designacao = _db.Designacoes.Find(request.Id);

                if (designacao == null)
                    throw new NaoEncontradoException(nameof(Designacao), request.Id);

                _db.Designacoes.Remove(designacao);
                await _db.SaveChangesAsync(cancellationToken);

                _info.Sucess();
            }
            catch(NaoEncontradoException ex)
            {
                _info.AddFailure("Designacao não encontrada", ex);
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
