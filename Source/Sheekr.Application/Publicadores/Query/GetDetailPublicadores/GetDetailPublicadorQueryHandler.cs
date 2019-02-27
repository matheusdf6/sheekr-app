using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetDetailPublicadorQueryHandler : IRequestHandler<GetDetailPublicadorQuery, RequestInfo<PublicadorDetailModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<PublicadorDetailModel> _info;

        public GetDetailPublicadorQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<PublicadorDetailModel>();
        }

        public async Task<RequestInfo<PublicadorDetailModel>> Handle(GetDetailPublicadorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publicador = await _db.Publicadores
                                    .Include(p => p.Aluno)
                                    .Include(p => p.Dirigente)
                                    .Include(p => p.Orador)
                                    .Select(p => new PublicadorDetailModel
                                    {
                                        PublicadorId = p.PublicadorId,
                                        NomeCompleto = p.NomeCompleto,
                                        Sexo = p.Sexo.ToString(),
                                        Privilegio = p.Privilegio.ToString(),
                                        Telefone = p.Telefone,
                                        Email = p.Email,
                                        IsAluno = (p.Aluno != null),
                                        IsOrador = (p.Orador != null),
                                        IsDirigente = (p.Dirigente != null)
                                    })
                                    .FirstAsync(p => p.PublicadorId == request.PublicadorId);

                if (publicador == null)
                    throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

                _info.Sucess();
                _info.AddResponde(publicador);
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
