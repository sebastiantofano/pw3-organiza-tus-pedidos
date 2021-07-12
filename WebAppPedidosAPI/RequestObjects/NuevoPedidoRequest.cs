using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.RequestObjects
{
    public class NuevoPedidoRequest
    {
        public int IdCliente { get; set; }

        public int ModificadoPor { get; set; }

        public List<PedidoArticuloRequest> Articulos { get; set; }
    }
}
