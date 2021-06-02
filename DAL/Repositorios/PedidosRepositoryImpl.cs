using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class PedidosRepositoryImpl : BaseRepositoryImpl<Pedido>, IPedidosRepository
    {
        private readonly PedidosPW3Context pedidosPW3Context;
        public PedidosRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context)
        {
            this.pedidosPW3Context = pedidosPW3Context;
        }
    }
}
