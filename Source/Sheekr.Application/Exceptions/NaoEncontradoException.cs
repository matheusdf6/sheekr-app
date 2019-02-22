using System;
using System.Collections.Generic;
using System.Text;

namespace Sheekr.Application.Exceptions
{
    class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string name, object key) 
        : base($"A entidade \"{name}\" ({key}) não foi encontrada")
        {

        }
    }
}
