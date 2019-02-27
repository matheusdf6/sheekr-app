using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Data;

namespace Sheekr.Application.Security.Query
{
    public class GetAllUsuariosQueryHandler
        : IRequestHandler<GetAllUsuariosQuery, RequestInfo<UsuarioListViewModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<UsuarioListViewModel> _info;

        public GetAllUsuariosQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<UsuarioListViewModel>();
        }

        public async Task<RequestInfo<UsuarioListViewModel>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new UsuarioListViewModel
                {
                    Usuarios = await _db.Usuarios
                                .Select(u => new UsuarioDetailModel
                                {
                                    Id = u.Id,
                                    PrimeiroNome = u.FirstName,
                                    UltimoNome = u.LastName,
                                    UserName = u.UserName
                                })
                                .ToListAsync()
                };

                _info.Sucess();
                _info.AddResponde(vm);
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
