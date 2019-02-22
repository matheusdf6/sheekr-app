using System;

namespace Sheekr.Domain.Entities
{
    public class DiscursoFora
    {
        public int DiscursoForaId { get; set; }
        public int OradorForaId { get; set; }
        public int TemaId { get; set; }
        public DateTime Data { get; set; }

        // Navegação
        public virtual OradorFora OradorFora { get; set; }        
        public virtual Tema Tema { get; set; }
    }
}
