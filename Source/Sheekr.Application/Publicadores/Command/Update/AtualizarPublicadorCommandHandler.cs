using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Command
{
    public class AtualizarPublicadorCommandHandler : IRequestHandler<AtualizarPublicadorCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo _info;

        public AtualizarPublicadorCommandHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(AtualizarPublicadorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publicador = await _db.Publicadores.FindAsync(request.PublicadorId);

                if (publicador == null)
                    throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

                publicador.PrimeiroNome = request.PrimeiroNome;
                publicador.UltimoNome = request.UltimoNome;
                publicador.Email = (request.Email != null) ? request.Email.Trim() : null;
                publicador.Telefone = (request.Telefone != null) ? request.Telefone.Trim() : null;
                publicador.Sexo = request.Sexo;
                publicador.Privilegio = request.Privilegio;

                _db.Publicadores.Update(publicador);

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
