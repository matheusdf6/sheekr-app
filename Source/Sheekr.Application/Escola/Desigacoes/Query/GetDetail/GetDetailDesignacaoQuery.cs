using MediatR;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetDetailDesignacaoQuery : IRequest<DesignacaoDetailModel>
    {
        public int Id { get; set; }
    }
}
