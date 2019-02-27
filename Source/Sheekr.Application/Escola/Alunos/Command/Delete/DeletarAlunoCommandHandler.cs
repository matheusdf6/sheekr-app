using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    /// Classe que faz o tratamento do comando "DeletarAlunoCommand" dentro da pipeline MediatR
    /// </summary>
    public class DeletarAlunoCommandHandler : IRequestHandler<DeletarAlunoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo info;

        public DeletarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
            info = new RequestInfo();
        }

        /// <summary>
        /// Tratamento do comando DeletarAlunoCommand
        /// </summary>
        /// <param name="request">Um objeto que implementa "MediatR.IRequest"</param>
        /// <param name="cancellationToken">Token para cancelamento da thread</param>
        /// <returns></returns>
        public async Task<RequestInfo> Handle(DeletarAlunoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var aluno = await _db.Alunos.FindAsync(request.AlunoId);

                if (aluno == null)
                    throw new NaoEncontradoException(nameof(Sheekr.Domain.Entities.Aluno), request.AlunoId);

                _db.Alunos.Remove(aluno);
                await _db.SaveChangesAsync(cancellationToken);

                info.Sucess();
            }
            catch(NaoEncontradoException ex)
            {
                info.AddFailure("Entidade não encontrada dentro do banco de dados", ex);
            }
            catch (DbException ex)
            {
                info.AddFailure("Erro ocorrido ao fazer conexão com banco de dados", ex);
            }
            catch (Exception ex)
            {
                info.AddFailure($"Erro! Conferir descrição. ", ex);
            }

            return info;
        }
    }
}
