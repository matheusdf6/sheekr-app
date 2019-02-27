using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Entities.Enum;

namespace Sheekr.Application.Security
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly UserService _userService;
        private readonly RequestInfo _info;

        public CreateUserCommandHandler(SheekrDbContext db, UserService userService)
        {
            this._db = db;
            this._userService = userService;
            this._info = new RequestInfo();
        }

        public async Task<RequestInfo> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sucess = await _userService.CreateUserAsync(new Usuario
                {
                    FirstName = request.PrimeiroNome,
                    LastName = request.UltimoNome,
                    UserName = request.UserName
                }, request.Password, (request.Role ?? Role.NaoAutorizado));

                if (sucess == false)
                    throw new Exception("Não foi possivel criar um novo usuário");
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
