using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios;
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
        public PedidosServiceImpl() : base(new PedidosRepositoryImpl())
        {
        }
    }
}
