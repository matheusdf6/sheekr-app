using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sheekr.Application.Escola.Licoes.Command
{
    public class CriarLicaoCommand : IRequest<RequestInfo>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}
