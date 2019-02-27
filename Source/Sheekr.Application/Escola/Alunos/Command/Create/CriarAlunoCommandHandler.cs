using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sheekr.Domain.Entities;
using Sheekr.Data;
using Sheekr.Application.Exceptions;
using System.Data.Common;
using System;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    /// Classe que faz o tratamento do comando "CriarAlunoCommand" dentro da pipeline MediatR
    /// </summary>
    public class CriarAlunoCommandHandler : IRequestHandler<CriarAlunoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo info;

        public CriarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
            info = new RequestInfo();
        }

        /// <summary>
        /// Tratamento do comando CriarAlunoCommand
        /// </summary>
        /// <param name="request">Um objeto que implementa "MediatR.IRequest"</param>
        /// <param name="cancellationToken">Token para cancelamento da thread</param>
        /// <returns></returns>
        public async Task<RequestInfo> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _db.Publicadores.FindAsync(request.PublicadorId) == null)
                    throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

                _db.Alunos.Add(new Aluno()
                {
                    AlunoId = request.AlunoId,
                    PublicadorId = request.PublicadorId,
                    FazLeitura = request.FazLeitura,
                    FazDemonstracao = request.FazDemonstracao,
                    FazDiscurso = request.FazDiscurso
                });

                await _db.SaveChangesAsync(cancellationToken);
                info.Sucess();
            }      
            catch(NaoEncontradoException ex)
            {
                info.AddFailure("Não encontrado um publicador com a chave fornecida. É obrigatório informar um publicador já cadastrado", ex);
            }
            catch(DbException ex) 
            {
                info.AddFailure("Erro ocorrido ao fazer conexão com banco de dados", ex);
            }
            catch(Exception ex)
            {
                info.AddFailure($"Erro! Conferir descrição. ", ex);
            }

            return info;
        }
    }
}
