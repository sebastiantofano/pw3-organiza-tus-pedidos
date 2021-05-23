using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Helpers.Exceptions
{
    [Serializable]
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() { }

        public InvalidLoginException(string message) : base(message) { }
    }
}
