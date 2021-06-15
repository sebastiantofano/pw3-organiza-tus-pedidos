using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Exceptions
{
    public class ClienteException : Exception
    {
        public ClienteException() { }

        public ClienteException(string message) : base(message) { }
    
    }
}
