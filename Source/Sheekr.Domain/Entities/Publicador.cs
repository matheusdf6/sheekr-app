using Sheekr.Domain.Enum;
using System;

namespace Sheekr.Domain.Entities
{
    public class Publicador
    {
        public int PublicadorId { get; set; }
        public Genero Sexo { get; set; }
        public Privilegio Privilegio { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }

        public string PrimeiroNome { get; set; }
        public string UltimoNome {get; set;}
        public string NomeCompleto { get => PrimeiroNome + " " + UltimoNome; }

        // Navegação
        public virtual Aluno Aluno { get; set; }
        public virtual Dirigente Dirigente { get; set; }
        public virtual OradorLocal Orador { get; set; }
    }
}
