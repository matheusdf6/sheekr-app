using Sheekr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sheekr.Application.Escola.Alunos.Query
{
    public class AlunoDetailsModel
    {
        public int AlunoId { get; set; }
        public string NomePublicador { get; set; }
        public bool FazLeitura { get; set; }
        public bool FazDemonstracao { get; set; }
        public bool FazDiscurso { get; set; }

        public static Expression<Func<Aluno, AlunoDetailsModel>> Projection
        {
            get
            {
                return aluno => new AlunoDetailsModel()
                {
                    AlunoId = aluno.AlunoId,
                    NomePublicador = aluno.DadosPublicador.NomeCompleto,
                    FazDemonstracao = aluno.FazDemonstracao,
                    FazLeitura = aluno.FazLeitura,
                    FazDiscurso = aluno.FazDiscurso
                };
            }
        }

        public static AlunoDetailsModel Create(Aluno aluno)
        {
            return Projection.Compile().Invoke(aluno);
        }
    }
}
