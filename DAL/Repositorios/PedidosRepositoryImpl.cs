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
            _pedidosPW3Context.SaveChanges();
        }

        public void AgregarArticuloYCantidadAlPedido(PedidoArticulo pedidoArticulo)
        {
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
    }
}
