using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class DesignarCommandHandler : IRequestHandler<DesignarCommand>
    {
        private readonly SheekrDbContext _db;

        public DesignarCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }


        public async Task<Unit> Handle(DesignarCommand request, CancellationToken cancellationToken)
        {
            var designacao = new Designacao()
            {
                DesignacaoId = request.DesignacaoId,
                LicaoId = request.LicaoId,
                AlunoPrincipalId = request.AlunoPrincipalId,
                AlunoAjudanteId = request.AlunoAjudanteId,
                Data = request.Data,
                Tipo = request.Tipo,
                Local = request.Local
            };

            _db.Designacoes.Add(designacao);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
