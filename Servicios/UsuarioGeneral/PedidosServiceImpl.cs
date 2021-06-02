using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral
{
    public class PedidosServiceImpl : BaseServiceImpl<Pedido>, IPedidosService
    {
        private readonly IPedidosRepository pedidosRepository;
        public PedidosServiceImpl(IPedidosRepository pedidosRepository) : base(pedidosRepository)
        {
            this.pedidosRepository = pedidosRepository;
        }
    }
}
