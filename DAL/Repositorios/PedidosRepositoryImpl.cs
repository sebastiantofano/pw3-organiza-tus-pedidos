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
        private readonly PedidosPW3Context _pedidosPW3Context;
        public PedidosRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }

        public void AdicionarCantidadAlArticuloDelPedido(PedidoArticulo pedidoArticulo)
        {
            PedidoArticulo articuloAActualizarCantidad = _pedidosPW3Context.PedidoArticulos.Where(p => p.IdPedido == pedidoArticulo.IdPedido && p.IdArticulo == pedidoArticulo.IdArticulo).FirstOrDefault();
            articuloAActualizarCantidad.Cantidad += pedidoArticulo.Cantidad;
            if(articuloAActualizarCantidad.Cantidad <= 0)
            {
                articuloAActualizarCantidad.Cantidad = 0;
            }
            _pedidosPW3Context.SaveChanges();
        }

        public void AgregarArticuloYCantidadAlPedido(PedidoArticulo pedidoArticulo)
        {
            if (pedidoArticulo.Cantidad <= 0)
            {
                pedidoArticulo.Cantidad = 0;
            }
            _pedidosPW3Context.Add(pedidoArticulo);
            _pedidosPW3Context.SaveChanges();
        }

        public Dictionary<Articulo, int> ObtenerArticulosYCantidadesDelPedido(int idPedido)
        {
            List<PedidoArticulo> articulosContenidosEnPedido = _pedidosPW3Context.PedidoArticulos.Where(p => p.IdPedido == idPedido).ToList();

            Dictionary<Articulo, int> articulosYCantidadesDelPedido = new();

            foreach (PedidoArticulo articulo in articulosContenidosEnPedido)
            {
                articulosYCantidadesDelPedido.Add(articulo.IdArticuloNavigation, articulo.Cantidad);
            }

            return articulosYCantidadesDelPedido;

        }

        public bool ValidarExistenciaDeArticuloEnPedido(PedidoArticulo pedidoArticulo)
        {
            bool articuloYaExiste = _pedidosPW3Context.PedidoArticulos.Where(p => p.IdPedido == pedidoArticulo.IdPedido && p.IdArticulo == pedidoArticulo.IdArticulo).Count() > 0;

            return articuloYaExiste;
        }

        public override void Actualizar(Pedido pedido)
        {
            // Pasa de estar en estado Detached a Unchanged
            _pedidosPW3Context.Set<Pedido>().Attach(pedido);

            //Specify the fields that should be updated.
            _pedidosPW3Context.Entry(pedido).Property(x => x.Comentarios).IsModified = true;
            _pedidosPW3Context.Entry(pedido).Property(x => x.ModificadoPor).IsModified = true;
            _pedidosPW3Context.Entry(pedido).Property(x => x.FechaModificacion).IsModified = true;

            _pedidosPW3Context.SaveChanges();
        }

        public bool ComprobarExistenciaDeUnPedidoAbiertoDeCliente(int idCliente)
        {
            bool ExistePedidoAbiertoDeCliente = _pedidosPW3Context.Pedidos.Where(p => p.IdCliente == idCliente && p.IdEstado == 1 && p.FechaBorrado == null).Count() > 0;
            return ExistePedidoAbiertoDeCliente;
        }

        public void MarcarComoCerrado(int idPedido)
        {
            Pedido pedido = _pedidosPW3Context.Pedidos.Where(p => p.IdPedido == idPedido).FirstOrDefault();
            pedido.IdEstado = 2;
            _pedidosPW3Context.SaveChanges();
        }

        public void MarcarComoEntregado(int idPedido)
        {
            Pedido pedido = _pedidosPW3Context.Pedidos.Where(p => p.IdPedido == idPedido).FirstOrDefault();
            pedido.IdEstado = 3;
            _pedidosPW3Context.SaveChanges();
        }

        public void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo)
        {
            PedidoArticulo articuloAEliminarDelPedido = _pedidosPW3Context.PedidoArticulos.Where(p => p.IdPedido == pedidoArticulo.IdPedido && p.IdArticulo == pedidoArticulo.IdArticulo).FirstOrDefault();
            _pedidosPW3Context.PedidoArticulos.Remove(articuloAEliminarDelPedido);
            _pedidosPW3Context.SaveChanges();
        }
    }
}
