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

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class GetAlunoDetailsQueryHandler : IRequestHandler<GetAlunoDetailsQuery, RequestInfo<AlunoDetailsModel>>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo<AlunoDetailsModel> _info;

        public GetAlunoDetailsQueryHandler(SheekrDbContext db)
        {
            this._db = db;
            this._info = new RequestInfo<AlunoDetailsModel>();
        }

        public async Task<RequestInfo<AlunoDetailsModel>> Handle(GetAlunoDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var aluno = await _db.Alunos
                    .Include(a => a.DadosPublicador)
                    .Select(a => new AlunoDetailsModel
                    {
                        AlunoId = a.AlunoId,
                        NomePublicador = a.DadosPublicador.NomeCompleto,
                        FazDemonstracao = a.FazDemonstracao,
                        FazDiscurso = a.FazDiscurso,
                        FazLeitura = a.FazLeitura
                    })
                    .SingleAsync(a => a.AlunoId == request.AlunoId);

                if (aluno == null)
                    throw new NaoEncontradoException(nameof(Aluno), request.AlunoId);


                _info.Sucess();
                _info.AddResponde(aluno);
            }
            catch(NaoEncontradoException ex)            
            {
                _info.AddFailure("Aluno não encontrado", ex);
            }
            catch (InvalidOperationException)
            {
                _info.AddFailure("Aluno não encontrado", new NaoEncontradoException(nameof(Aluno), request.AlunoId));
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
