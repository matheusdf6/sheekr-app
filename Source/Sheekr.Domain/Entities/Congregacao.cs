using System;
using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class Congregacao
    {
        public int CongregacaoId { get; set; }
        public NomeCongregacao NomeCongregacao { get; set; }

        public virtual ICollection<OradorLocal> OradoresLocais { get; set; }
    }
}
