using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios.Interfaces
{
    public interface IPedidosRepository : IBaseRepository<Pedido> // Esta interface hereda todos los metodos del la interface del repositorio base
    {
        Dictionary<Articulo, int> ObtenerArticulosYCantidadesDelPedido(int idPedido);
        void AgregarArticuloYCantidadAlPedido(PedidoArticulo pedidoArticulo);
        bool ValidarExistenciaDeArticuloEnPedido(PedidoArticulo pedidoArticulo);
        void AdicionarCantidadAlArticuloDelPedido(PedidoArticulo pedidoArticulo);
        bool ComprobarExistenciaDeUnPedidoAbiertoDeCliente(int idCliente);
        void MarcarComoCerrado(int idPedido);
        void MarcarComoEntregado(int idPedido);
        void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo);
        int UltimoNumeroPedidoInsertadoParaCliente(int idCliente);
    }
}
