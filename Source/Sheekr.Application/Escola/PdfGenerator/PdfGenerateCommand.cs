using System.Text;
using MediatR;
using Sheekr.Domain.Enum;
using Sheekr.Application.Escola.Desigacoes.Query;
using System.Collections.Generic;

namespace Sheekr.Application.Escola.PdfGenerator
{
    public class PdfGenerateCommand : IRequest<bool>
    {
        public string NomeArquivo { get; set; }
        public List<int> Designacoes { get; set; }
    }
}

