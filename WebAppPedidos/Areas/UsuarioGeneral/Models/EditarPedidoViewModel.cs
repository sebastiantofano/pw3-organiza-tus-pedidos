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
    }
}
