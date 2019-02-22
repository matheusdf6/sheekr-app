using System;

namespace Sheekr.Domain.Entities
{
    public class Saida
    {
        public int SaidaId { get; set; }
        public int DirigenteId { get; set; }
        public int TerritorioId { get; set; }
        public DateTime Data { get; set; }

        // Navegação
        public virtual Dirigente Dirigente { get; set; }
        public virtual Territorio Territorio { get; set; }
    }
}
