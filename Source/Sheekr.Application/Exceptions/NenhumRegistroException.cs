using System;

namespace Sheekr.Application.Exceptions
{
    class NenhumRegistroException : Exception
    {
        public NenhumRegistroException(string name) 
            : base($"A tabela da entidade \"{ name }\" não possui nenhum registro")
        {

        }
    }
}
