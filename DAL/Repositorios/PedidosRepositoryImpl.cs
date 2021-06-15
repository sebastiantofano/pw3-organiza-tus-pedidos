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
    }
}
