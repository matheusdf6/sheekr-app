using Sheekr.Domain.Infraestrutura;
using System;
using System.Collections.Generic;

namespace Sheekr.Domain.Entities
{
    public class NomeCongregacao : ValueObject
    {
        public NomeCongregacao()
        {

        }

        public NomeCongregacao(string nome)
        {
            try
            {
                var index = nome.IndexOf("\\", StringComparison.Ordinal);
                NomeLocal = nome.Substring(0, index);
                Cidade = nome.Substring(index + 1);
            }
            catch(Exception e)
            {
                throw new CongregacaoInvalidaException(nome, e);
            }
        }

        public string NomeLocal { get; set; }
        public string Cidade { get; set; }

        public static implicit operator string(NomeCongregacao nome)
        {
            return nome.ToString();
        }

        public static explicit operator NomeCongregacao(string nome)
        {
            return new NomeCongregacao(nome);
        }

        public override string ToString()
        {
            return $"{NomeLocal}\\{Cidade}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return NomeLocal;
            yield return Cidade;
        }
    }
}
