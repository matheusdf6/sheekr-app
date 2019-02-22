using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class Dirigente
    {
        public Dirigente()
        {
            Saidas = new HashSet<Saida>();
        }

        public int DirigenteId { get; set; }
        public int PublicadorId { get; set; }

        // Navegação
        public virtual Publicador DadosPublicador { get; set; }
        public virtual ICollection<Saida> Saidas { get; set; }
    }
}
