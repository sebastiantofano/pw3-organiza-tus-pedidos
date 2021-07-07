using AutoMapper;
using DAL.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.RequestObjects;
using WebAPI.ResponseObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        private readonly IMapper _mapper; 

        public PedidosController(IPedidosService pedidosService, IMapper mapper)
        {
            _pedidosService = pedidosService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            List<Pedido> pedidos = _pedidosService.ObtenerTodos();
            List<PedidoResponse> pedidosResponse = new();
            foreach (Pedido pedido in pedidos)
            {
                PedidoResponse pedidoResponse = _mapper.Map<PedidoResponse>(pedido);
                List<ArticuloPedidoResponse> articulosDelPedido = _mapper.Map<List<ArticuloPedidoResponse>>(_pedidosService.ObtenerArticulosYCantidadesDelPedido(pedido.Id));
                pedidoResponse.Articulos = articulosDelPedido;
                pedidosResponse.Add(pedidoResponse);
            }
            return new {
                count = pedidosResponse.Count,
                pedidos = pedidosResponse
            };
        }

        [HttpPost]
        [Route("buscar")]
        public ActionResult<dynamic> BuscarPedido([FromBody] PedidosBusquedaRequest pedidosBusquedaRequest)
        {
            List<Pedido> pedidos = _pedidosService.BuscarPedidosPorCliente(pedidosBusquedaRequest.IdCliente);
            List<PedidoResponse> pedidosResponse = new();
            foreach (Pedido pedido in pedidos)
            {
                PedidoResponse pedidoResponse = _mapper.Map<PedidoResponse>(pedido);
                List<ArticuloPedidoResponse> articulosDelPedido = _mapper.Map<List<ArticuloPedidoResponse>>(_pedidosService.ObtenerArticulosYCantidadesDelPedido(pedido.Id));
                pedidoResponse.Articulos = articulosDelPedido;
                pedidosResponse.Add(pedidoResponse);
            }
            return new {
                count = pedidosResponse.Count,
                pedidos = pedidosResponse
            };
        }


    }
}
