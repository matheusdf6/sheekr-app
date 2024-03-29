﻿using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Enum;

namespace Sheekr.Application.Publicadores.Command
{
    public class CriarPublicadorCommand : IRequest<RequestInfo>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Genero Sexo { get; set; }
        public Privilegio Privilegio { get; set; }
    }
}
