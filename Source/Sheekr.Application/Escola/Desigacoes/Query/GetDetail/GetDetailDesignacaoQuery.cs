using MediatR;

namespace Sheekr.Application.Escola.Desigacoes.Query
{
    public class GetDetailDesignacaoQuery : IRequest<RequestInfo<DesignacaoDetailModel>>
    {
        public int Id { get; set; }
    }
}
