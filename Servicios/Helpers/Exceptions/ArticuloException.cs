using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Exceptions
{
    public class ArticuloException : Exception
    {
        public ArticuloException() { }

        public ArticuloException(string message) : base(message) { }
    }
}
