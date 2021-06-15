using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Exceptions
{
    public class PedidoException : Exception
    {
        public PedidoException() { }

        public PedidoException(string message) : base(message) { }

    }
}
