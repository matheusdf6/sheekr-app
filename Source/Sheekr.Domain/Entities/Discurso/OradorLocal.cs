using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class OradorLocal
    {
        public OradorLocal()
        {
            DiscursosFeitos = new HashSet<DiscursoLocal>();
        }

        public int OradorId { get; set; }        
        public int CongregacaoId { get; set; }
        public int PublicadorId { get; set; }

        public virtual Congregacao Congregacao { get; set; }
        public virtual Publicador DadosPublicador { get; set; }
        public virtual ICollection<DiscursoLocal> DiscursosFeitos { get; set; }

        public string PrimeiroNome { get => DadosPublicador.PrimeiroNome; set => DadosPublicador.PrimeiroNome = value; }
        public string UltimoNome { get => DadosPublicador.UltimoNome; set => DadosPublicador.UltimoNome = value;  }
    }
}
