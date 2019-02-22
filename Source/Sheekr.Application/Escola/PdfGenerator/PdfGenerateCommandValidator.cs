using FluentValidation;

namespace Sheekr.Application.Escola.PdfGenerator
{
    public class PdfGenerateCommandValidator : AbstractValidator<PdfGenerateCommand>
    {
        public PdfGenerateCommandValidator()
        {
            RuleFor(c => c.Designacoes).NotEmpty().Custom((designacoes, context) =>
            {
                if (designacoes.Count > 4)
                    context.AddFailure("Informe no máximo quatro designações");
            });
            RuleFor(c => c.NomeArquivo).NotEmpty();
        }
    }
}

