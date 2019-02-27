using System;
using Sheekr.Data;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class AtualizarDesignacaoCommandHandler
        : IRequestHandler<AtualizarDesignacaoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public AtualizarDesignacaoCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(AtualizarDesignacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var designacao = await _db.Designacoes.FindAsync(request.DesignacaoId);

                if (designacao == null || designacao.DesignacaoId != request.DesignacaoId)
                    throw new NaoEncontradoException(nameof(Designacao), request.DesignacaoId);

                designacao.DesignacaoId = request.DesignacaoId;
                designacao.AlunoPrincipalId = request.AlunoPrincipalId;
                designacao.AlunoAjudanteId = request.AlunoAjudanteId;
                designacao.LicaoId = request.LicaoId;
                designacao.Local = request.Local;
                designacao.Tipo = request.Tipo;
                designacao.Data = request.Data;

                _db.Designacoes.Update(designacao);
                await _db.SaveChangesAsync(cancellationToken);

                _info.Sucess();
            }
            catch (NaoEncontradoException ex)
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
