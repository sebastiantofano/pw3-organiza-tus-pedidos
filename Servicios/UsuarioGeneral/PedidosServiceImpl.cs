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
            int idIUltimoPedidoInsertadoParaCliente = _pedidosRepository.UltimoNumeroPedidoInsertadoParaCliente(pedido.IdCliente);
            pedido.NroPedido = idIUltimoPedidoInsertadoParaCliente + 1;
            return base.Insertar(pedido);
        }

        public override void Actualizar(Pedido pedido)
        {
            pedido.Comentarios = pedido.Comentarios;
            base.Actualizar(pedido);
        }

        public void MarcarComoCerrado(int idPedido)
        {
            Pedido pedido = _pedidosRepository.ObtenerPorId(idPedido);

            if(!(pedido.IdEstado == (int)EstadoPedidoEnum.ABIERTO))
            {
                throw new PedidoException("El pedido ya se encuentra Cerrado o Entregado");
            }

            _pedidosRepository.MarcarComoCerrado(idPedido);

        }

        public void MarcarComoEntregado(int idPedido)
        {
            Pedido pedido = _pedidosRepository.ObtenerPorId(idPedido);

            if (!(pedido.IdEstado == (int)EstadoPedidoEnum.CERRADO))
            {
                throw new PedidoException("El pedido no se encuentra cerrado");
            }

            _pedidosRepository.MarcarComoEntregado(idPedido);
        }

        public void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo)
        {
            _pedidosRepository.EliminarArticuloAlPedido(pedidoArticulo);
        }

        public List<Pedido> BuscarPedidosPorCliente(int idCliente)
        {
            return _pedidosRepository.BuscarPedidosPorCliente(idCliente);
        }

        public int CrearPedidoAPI(Pedido pedido)
        {
            bool existePedidoAbiertoDeCliente = _pedidosRepository.ComprobarExistenciaDeUnPedidoAbiertoDeCliente(pedido.IdCliente);
            if (existePedidoAbiertoDeCliente)
            {
                Cliente cliente = _clientesRepository.ObtenerPorId(pedido.IdCliente);
                throw new PedidoException($"Ya existe un pedido abierto para el cliente {cliente.Nombre}");
            }
            pedido.IdEstado = (int)EstadoPedidoEnum.ABIERTO;
            int idIUltimoPedidoInsertadoParaCliente = _pedidosRepository.UltimoNumeroPedidoInsertadoParaCliente(pedido.IdCliente);
            pedido.NroPedido = idIUltimoPedidoInsertadoParaCliente + 1;
            return _pedidosRepository.CrearPedidoAPI(pedido);
        }

        public void AgregarArticuloYCantidadAlPedidoAPI(PedidoArticulo pedidoArticulo)
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
        }
    }
}
