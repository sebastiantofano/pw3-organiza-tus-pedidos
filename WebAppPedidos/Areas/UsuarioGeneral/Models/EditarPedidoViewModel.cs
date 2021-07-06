using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Models
{
    public class EditarPedidoViewModel
    {
        public Pedido Pedido { get; set; }

        public PedidoArticulo PedidoArticulo { get; set; }

        public List<Articulo> SelectArticulosDisponibles { get; set; }

        public Dictionary<Articulo, int> ArticulosYCantidadesDelPedido { get; set; }

        public List<Cliente> SelectClientesDisponibles { get; set; }

    }
}
