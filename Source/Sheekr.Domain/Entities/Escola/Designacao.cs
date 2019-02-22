using Sheekr.Domain.Enum;
using System;

namespace Sheekr.Domain.Entities
{
    public class Designacao
    {
        public int DesignacaoId { get; set; }
        public int AlunoPrincipalId { get; set; }
        public int? AlunoAjudanteId { get; set; }
        public int LicaoId { get; set; }

        public DateTime Data { get; set; }
        public TipoDesignacaoEscola Tipo { get; set; }
        public LocalDesignacao Local { get; set; }

        // Navegação
        public virtual Aluno AlunoPrincipal { get; set; }
        public virtual Aluno AlunoAjudante { get; set; }
        public virtual Licao Licao { get; set; }
    }
}
