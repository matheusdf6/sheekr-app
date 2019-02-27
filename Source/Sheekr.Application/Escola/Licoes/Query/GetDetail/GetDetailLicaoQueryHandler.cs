using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Sheekr.Application.Exceptions;
using System;
using System.Data.Common;

namespace Sheekr.Application.Escola.Licoes.Query
{
    public class GetDetailLicaoQueryHandler : IRequestHandler<GetDetailLicaoQuery, RequestInfo<Licao>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<Licao> _info;

        public GetDetailLicaoQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<Licao>();
        }

        public async Task<RequestInfo<Licao>> Handle(GetDetailLicaoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var licao = await _db.Licoes.FindAsync(request.Id);

                if (licao == null)
                    throw new NaoEncontradoException(nameof(Licao), request.Id);

                _info.Sucess();
                _info.AddResponde(licao);
            }
            catch(NaoEncontradoException ex)
            {
                _info.AddFailure("Licão não encontrada", ex);
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
