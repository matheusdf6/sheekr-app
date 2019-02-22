using Sheekr.Domain.Entities;
using Sheekr.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sheekr.Application.Publicadores.Query
{
    public class PublicadorDetailModel
    {
        public int PublicadorId { get; set; }
        public string Sexo { get; set; }
        public string Privilegio { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeCompleto { get; set; }
        public bool IsAluno { get; set; }
        public bool IsOrador { get; set; }
        public bool IsDirigente { get; set; }

        public static Expression<Func<Publicador,PublicadorDetailModel>> Projection
        {
            get
            {
                return publicador => new PublicadorDetailModel
                {
                    PublicadorId = publicador.PublicadorId,
                    NomeCompleto = publicador.NomeCompleto,
                    Email = publicador.Email,
                    Telefone = publicador.Telefone,
                    Privilegio = publicador.Privilegio.ToString(),
                    Sexo = publicador.Sexo.ToString(),
                    IsAluno = (publicador.Aluno != null),
                    IsOrador = (publicador.Orador != null),
                    IsDirigente = (publicador.Dirigente != null)
                };
            }
        }

        public static PublicadorDetailModel Create(Publicador publicador)
        {
            return Projection.Compile().Invoke(publicador);
        }
    }
}
