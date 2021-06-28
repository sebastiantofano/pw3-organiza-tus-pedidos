using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Helpers.Enums;
using Servicios.Helpers.Exceptions;
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
        private readonly IClientesRepository _clientesRepository;
        public PedidosServiceImpl(IPedidosRepository pedidosRepository, IClientesRepository clientesRepository, IHttpContextAccessor httpContextAccessor) : base(pedidosRepository, httpContextAccessor)
        {
            _pedidosRepository = pedidosRepository;
            _clientesRepository = clientesRepository;
        }

        public void AgregarArticuloYCantidadAlPedido(PedidoArticulo pedidoArticulo)
        {
            bool articuloYaExiste = _pedidosRepository.ValidarExistenciaDeArticuloEnPedido(pedidoArticulo);

            if (articuloYaExiste)
            {
                _pedidosRepository.AdicionarCantidadAlArticuloDelPedido(pedidoArticulo);
            }
            else
            {
                _pedidosRepository.AgregarArticuloYCantidadAlPedido(pedidoArticulo);
            }

            Pedido pedidoAActualizar = _pedidosRepository.ObtenerPorId(pedidoArticulo.IdPedido);
            base.Actualizar(pedidoAActualizar);

        }

        public Dictionary<Articulo, int> ObtenerArticulosYCantidadesDelPedido(int idPedido)
        {
            return _pedidosRepository.ObtenerArticulosYCantidadesDelPedido(idPedido);
        }

        /* Sobrescribimos el metodo Insertar "Virtual" del Servicio Base ya que queremos agregar validaciones extras en la capa de Servicios */
        public override int Insertar(Pedido pedido)
        {
            bool existePedidoAbiertoDeCliente = _pedidosRepository.ComprobarExistenciaDeUnPedidoAbiertoDeCliente(pedido.IdCliente);
            if (existePedidoAbiertoDeCliente)
            {
                Cliente cliente = _clientesRepository.ObtenerPorId(pedido.IdCliente);
                throw new PedidoException($"Ya existe un pedido abierto para el cliente {cliente.Nombre}");
            }
            pedido.IdEstado = (int)EstadoPedidoEnum.ABIERTO;
            return base.Insertar(pedido);
        }

        public override void Actualizar(Pedido pedido)
        {
            pedido.Comentarios = pedido.Comentarios;
            base.Actualizar(pedido);
        }

    }
}
