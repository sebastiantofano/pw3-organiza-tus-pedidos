using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException() { }

        public UsuarioException(string message) : base(message) { }
    
    }
}
