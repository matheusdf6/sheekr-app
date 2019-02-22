using MediatR;
using Sheekr.Domain.Entities;
using System.Collections.Generic;

namespace Sheekr.Application.Publicadores.Query
{
    public class GetAllPublicadorQuery : IRequest<List<PublicadorDetailModel>>
    {
        
    }

}
