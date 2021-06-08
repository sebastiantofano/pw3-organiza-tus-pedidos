using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PedidosServiceImpl(IPedidosRepository pedidosRepository, IHttpContextAccessor httpContextAccessor) : base(pedidosRepository, httpContextAccessor)
        {
            _pedidosRepository = pedidosRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
