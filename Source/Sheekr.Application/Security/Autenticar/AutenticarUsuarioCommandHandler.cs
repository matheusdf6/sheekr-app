using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Data.Common;
using Sheekr.Application.Exceptions;

namespace Sheekr.Application.Security
{
    public class AutenticarUsuarioCommandHandler
        : IRequestHandler<AutenticarUsuarioCommand, RequestInfo<UsuarioDto>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<UsuarioDto> _info;
        private readonly UserService _userService;

        public AutenticarUsuarioCommandHandler(SheekrDbContext db, UserService userService)
        {
            this._db = db;
            this._info = new RequestInfo<UsuarioDto>();
            this._userService = userService;
        }

        public async Task<RequestInfo<UsuarioDto>> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(request.UserName, request.Password);
                if (user == null)
                    throw new NaoEncontradoException("Usuário ou senha não encontrados", request.UserName);

                _info.Sucess();
                _info.AddResponde(user);
            }
            catch(NaoEncontradoException ex)
            {
                _info.AddFailure("Autenticação falhou", ex);
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
