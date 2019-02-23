using System;
using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class Aluno
    {
        public Aluno()
        {
            DesignacoesPrincipal = new HashSet<Designacao>();
            DesignacoesAjudante = new HashSet<Designacao>();
        }

        public int AlunoId { get; set; }
        public int PublicadorId { get; set; }

        public bool FazLeitura { get; set; }
        public bool FazDemonstracao { get; set; }
        public bool FazDiscurso { get; set; }

        public virtual Publicador DadosPublicador { get; set; }
        public virtual ICollection<Designacao> DesignacoesPrincipal { get; set; }
        public virtual ICollection<Designacao> DesignacoesAjudante { get; set; }
    }
}
