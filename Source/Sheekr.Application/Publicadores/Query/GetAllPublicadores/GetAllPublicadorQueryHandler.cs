using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetAllPublicadorQueryHandler : IRequestHandler<GetAllPublicadorQuery, RequestInfo<PublicadorListViewModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<PublicadorListViewModel> _info;

        public GetAllPublicadorQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<PublicadorListViewModel>();
        }

        public async Task<RequestInfo<PublicadorListViewModel>> Handle(GetAllPublicadorQuery request, CancellationToken cancellationToken)
        {          
            try
            {
                var vm = new PublicadorListViewModel
                {
                    Publicadores = await _db.Publicadores
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
