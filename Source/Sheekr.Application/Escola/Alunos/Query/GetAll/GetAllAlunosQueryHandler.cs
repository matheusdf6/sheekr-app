using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sheekr.Data;
using System.Data.Common;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAllAlunosQueryHandler : IRequestHandler<GetAllAlunosQuery, RequestInfo<AlunoListViewModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<AlunoListViewModel> _info;

        public GetAllAlunosQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<AlunoListViewModel>();
        }

        public async Task<RequestInfo<AlunoListViewModel>> Handle(GetAllAlunosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new AlunoListViewModel
                {
                    Alunos = await _db.Alunos
                        .Include(a => a.DadosPublicador)
                        .Select(a => new AlunoDetailsModel
                        {
                            AlunoId = a.AlunoId,
                            NomePublicador = a.DadosPublicador.NomeCompleto,
                            FazDemonstracao = a.FazDemonstracao,
                            FazDiscurso = a.FazDiscurso,
                            FazLeitura = a.FazLeitura
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
