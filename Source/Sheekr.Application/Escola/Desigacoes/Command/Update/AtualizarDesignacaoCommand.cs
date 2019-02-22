using System;
using System.Collections.Generic;
using System.Text;
using Sheekr.Data;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Enum;
using MediatR;
using FluentValidation;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Sheekr.Application.Escola.Desigacoes.Command
{
    public class AtualizarDesignacaoCommand : IRequest<Unit>
    {
        public int DesignacaoId { get; set; }
        public int LicaoId { get; set; }
        public int AlunoPrincipalId { get; set; }
        public int? AlunoAjudanteId { get; set; }
        public DateTime Data { get; set; }
        public TipoDesignacaoEscola Tipo { get; set; }
        public LocalDesignacao Local { get; set; }
    }

    public class AtualizarDesignacaoCommandHandler
        : IRequestHandler<AtualizarDesignacaoCommand, Unit>
    {
        private readonly SheekrDbContext _db;

        public AtualizarDesignacaoCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<Unit> Handle(AtualizarDesignacaoCommand request, CancellationToken cancellationToken)
        {
            var designacao = await _db.Designacoes.FindAsync(request.DesignacaoId);

            if (designacao == null || designacao.DesignacaoId != request.DesignacaoId)
                throw new NaoEncontradoException(nameof(Designacao), request.DesignacaoId);

            designacao.DesignacaoId = request.DesignacaoId;
            designacao.AlunoPrincipalId = request.AlunoPrincipalId;
            designacao.AlunoAjudanteId = request.AlunoAjudanteId;
            designacao.LicaoId = request.LicaoId;
            designacao.Local = request.Local;
            designacao.Tipo = request.Tipo;
            designacao.Data = request.Data;

            _db.Designacoes.Update(designacao);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class AtualizarDesignacaoCommandValidator : AbstractValidator<AtualizarDesignacaoCommand>
    {
        public AtualizarDesignacaoCommandValidator()
        {
            RuleFor(d => d.DesignacaoId).NotEmpty();
            RuleFor(d => d.AlunoPrincipalId).NotNull();
            RuleFor(d => d.LicaoId).InclusiveBetween(1, 20);
            RuleFor(d => d.Local).IsInEnum();
            RuleFor(d => d.Tipo).IsInEnum();
            RuleFor(d => d.Data).GreaterThan(new DateTime(2019, 1, 1));
        }
    }
}
