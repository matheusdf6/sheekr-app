using System;
using System.Runtime.Serialization;

namespace Sheekr.Domain.Entities
{
    public class CongregacaoInvalidaException : Exception
    {
        public CongregacaoInvalidaException(string nome, Exception innerException) 
            : base($"O nome de congregacao \"{nome}\" é inválido", innerException)
        {
        }
    }
}