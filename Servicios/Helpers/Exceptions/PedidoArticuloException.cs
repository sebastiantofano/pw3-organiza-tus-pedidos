using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Exceptions
{
    public class PedidoArticuloException : Exception
    {
        public PedidoArticuloException() { }

        public PedidoArticuloException(string message) : base(message) { }

    }
}
