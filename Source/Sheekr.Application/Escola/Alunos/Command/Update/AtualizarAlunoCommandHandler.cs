using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Alunos.Command
{
    /// <summary>
    /// Classe que faz o tratamento do comando "AtualizarAlunoCommand" dentro da pipeline MediatR
    /// </summary>
    public class AtualizarAlunoCommandHandler : IRequestHandler<AtualizarAlunoCommand, RequestInfo>
    {
        private readonly SheekrDbContext _db;
        private readonly RequestInfo info;

        public AtualizarAlunoCommandHandler(SheekrDbContext db)
        {
            _db = db;
            info = new RequestInfo();
        }

        /// <summary>
        /// Tratamento do comando AtualizarAlunoCommand
        /// </summary>
        /// <param name="request">Um objeto que implementa "MediatR.IRequest"</param>
        /// <param name="cancellationToken">Token para cancelamento da thread</param>
        /// <returns></returns>
        public async Task<RequestInfo> Handle(AtualizarAlunoCommand request, CancellationToken cancellationToken)
        {
            try
            {                
                if (await _db.Publicadores.FindAsync(request.PublicadorId) == null)
                    throw new NaoEncontradoException(nameof(Publicador), request.PublicadorId);

                var aluno = await _db.Alunos.FindAsync(request.AlunoId);
                if (aluno == null)
                    throw new NaoEncontradoException(nameof(Sheekr.Domain.Entities.Aluno), request.AlunoId);

                aluno.PublicadorId = request.PublicadorId;
                aluno.FazDemonstracao = request.FazDemonstracao;
                aluno.FazLeitura = request.FazLeitura;
                aluno.FazDiscurso = request.FazDiscurso;

                _db.Alunos.Update(aluno);

                await _db.SaveChangesAsync(cancellationToken);
            }
            catch(NaoEncontradoException ex)
            {
                info.AddFailure("Não encontrado um publicador com a chave fornecida. É obrigatório informar um publicador já cadastrado", ex);
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
