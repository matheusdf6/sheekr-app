using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;

namespace Sheekr.Application.Security.Query
{
    public class GetDetailUsuariosQueryHandler
        : IRequestHandler<GetDetailUsuariosQuery, RequestInfo<UsuarioDetailModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<UsuarioDetailModel> _info;

        public GetDetailUsuariosQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<UsuarioDetailModel>();
        }

        public async Task<RequestInfo<UsuarioDetailModel>> Handle(GetDetailUsuariosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _db.Usuarios
                    .Where(u => u.Id == request.Id)
                    .Select(u => new UsuarioDetailModel
                    {
                        Id = u.Id,
                        PrimeiroNome = u.FirstName,
                        UltimoNome = u.LastName,
                        UserName = u.UserName
                    })
                    .SingleOrDefaultAsync();

                if (user == null)
                    throw new NaoEncontradoException(nameof(Usuario), request.Id);

                _info.Sucess();
                _info.AddResponde(user);
            }
            catch (NaoEncontradoException ex)
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
