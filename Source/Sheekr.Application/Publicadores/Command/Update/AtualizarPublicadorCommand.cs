using MediatR;
using Sheekr.Application.Exceptions;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Enum;

namespace Sheekr.Application.Publicadores.Command
{
    public class AtualizarPublicadorCommand : IRequest
    {
        public int PublicadorId { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Genero Sexo { get; set; }
        public Privilegio Privilegio { get; set; }

        public Publicador RetornarPublicador()
        {
            return new Publicador
            {
                PublicadorId = this.PublicadorId,
                PrimeiroNome = this.PrimeiroNome,
                UltimoNome = this.UltimoNome,
                Email = this.Email,
                Telefone = this.Telefone,
                Sexo = this.Sexo,
                Privilegio = this.Privilegio
            };
        }
    }
}
