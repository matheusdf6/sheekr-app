using Sheekr.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class Territorio
    {
        public Territorio()
        {
            DiasTrabalhados = new HashSet<Saida>();
        }

        public int TerritorioId { get; set; }
        public Local Local { get; set; }
        public string Descricao { get; set; }

        public string UrlImagem { get; set; }

        // NAVEGAÇÃO
        public virtual ICollection<Saida> DiasTrabalhados { get; set; }
    }
}
