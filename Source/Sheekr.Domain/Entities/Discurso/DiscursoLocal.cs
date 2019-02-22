using System;

namespace Sheekr.Domain.Entities
{
    public class DiscursoLocal
    {
        public int DiscursoLocalId { get; set; }
        public int OradorId { get; set; }
        public int TemaId { get; set; }
        public int CongregacaoId { get; set; }
        public DateTime Data { get; set; }

        // Navegação
        public virtual OradorLocal OradorLocal { get; set; }
        public virtual Tema Tema { get; set; }
        public virtual Congregacao Congregacao { get; set; }
    }
}
