using System;
using System.Collections.Generic;
using MediatR;
using Sheekr.Data;
using Sheekr.Domain.Entities;
using Sheekr.Application.Resources;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using Sheekr.Application.Exceptions;

namespace Sheekr.Application.Escola.PdfGenerator
{
    public class PdfGenerateCommandHandler
        : IRequestHandler<PdfGenerateCommand, bool>
    {
        private readonly SheekrDbContext _db;
        private string _pathTemplate = @"C:\Users\mathe\source\repos\Sheekr\Sheekr.Application\Resources\S-89-T-4up.pdf";
        private string _pathNewPdf = @"C:\Users\mathe\source\repos\Sheekr\Sheekr.Application\Resources\GeneratedFiles\" ;

        public PdfGenerateCommandHandler(SheekrDbContext db)
        {
            this._db = db; 
        }

        public async Task<bool> Handle(PdfGenerateCommand request, CancellationToken cancellationToken)
        {
            var list = new List<Designacao>();
            foreach(var id in request.Designacoes)
            {
                var designacao = await _db.Designacoes
                .Include(q => q.AlunoPrincipal)
                        .ThenInclude(a => a.DadosPublicador)
                .Include(q => q.AlunoAjudante)
                        .ThenInclude(a => a.DadosPublicador)
                .FirstAsync(q => q.DesignacaoId == id);

                if (designacao == null || designacao.DesignacaoId != id)
                    throw new NaoEncontradoException(nameof(Designacao), id);

                list.Add(designacao);
            }

            using (var reader = new PdfReader(_pathTemplate))
            {
                PdfStamper stamper = null;
                try
                {
                    stamper = new PdfStamper(reader, new FileStream(_pathNewPdf + request.NomeArquivo, FileMode.Create));
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw ex;
                }

                AcroFields fields = stamper.AcroFields;                

                try
                {
                    int i = 1;
                    foreach(var designacao in list)
                    {
                        fields.SetFieldProperty(PdfConstants.Partes[i].GetValueOrDefault("NomePrincipal"), "textsize", 12f, null);
                        fields.SetField(PdfConstants.Partes[i].GetValueOrDefault("NomePrincipal"), designacao.AlunoPrincipal.DadosPublicador.NomeCompleto);
                        if (designacao.AlunoAjudante != null)
                        {
                            fields.SetFieldProperty(PdfConstants.Partes[i].GetValueOrDefault("NomeAjudante"), "textsize", 12f, null);
                            fields.SetField(PdfConstants.Partes[i].GetValueOrDefault("NomeAjudante"), designacao.AlunoAjudante.DadosPublicador.NomeCompleto);
                        }
                        fields.SetFieldProperty(PdfConstants.Partes[i].GetValueOrDefault("Data"), "textsize", 12f, null);
                        fields.SetField(PdfConstants.Partes[i].GetValueOrDefault("Data"), designacao.Data.ToShortDateString());
                        fields.SetField(PdfConstants.Partes[i].GetValueOrDefault(designacao.Tipo.ToString()), "Yes");
                        fields.SetField(PdfConstants.Partes[i].GetValueOrDefault(designacao.Local.ToString()), "Yes");
                        i++;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }

                stamper.Dispose();
                return true;
            }
        }
    }
}

