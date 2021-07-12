using AutoMapper;
using DAL.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Exceptions;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
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


        [HttpPost]
        [Route("guardar")]
        public ActionResult<dynamic> GuardarPedido([FromBody] NuevoPedidoRequest nuevoPedidoRequest)
        {
            Pedido nuevoPedido = _mapper.Map<Pedido>(nuevoPedidoRequest);
            nuevoPedido.IdCliente = nuevoPedidoRequest.IdCliente;
            nuevoPedido.CreadoPor = nuevoPedidoRequest.CreadoPor;

            try
            {
                int idPedidoInsertado = _pedidosService.CrearPedidoAPI(nuevoPedido);
                List<PedidoArticulo> pedidoArticulos = _mapper.Map<List<PedidoArticulo>>(nuevoPedidoRequest.Articulos);
                foreach (PedidoArticulo pedidoArticulo in pedidoArticulos)
                {
                    pedidoArticulo.IdPedido = idPedidoInsertado;
                    _pedidosService.AgregarArticuloYCantidadAlPedidoAPI(pedidoArticulo);
                }
                return new {
                    mensaje = "Pedido guardado exitosamente"
                };
            }
            catch(PedidoException e)
            {
                return new {
                    mensaje = e.Message
                };
            } 
        }
    }
}
