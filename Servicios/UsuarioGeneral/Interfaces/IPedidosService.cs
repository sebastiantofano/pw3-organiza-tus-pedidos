﻿using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral.Interfaces
{
    public interface IPedidosService : IBaseService<Pedido>
    {
        Dictionary<Articulo, int> ObtenerArticulosYCantidadesDelPedido(int idPedido);
        void AgregarArticuloYCantidadAlPedido(PedidoArticulo pedidoArticulo);
        void MarcarComoCerrado(int idPedido);
        void MarcarComoEntregado(int idPedido);
        void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo);
        List<Pedido> BuscarPedidosPorCliente(int idCliente);
        int CrearPedidoAPI(Pedido pedido);

        void AgregarArticuloYCantidadAlPedidoAPI(PedidoArticulo pedidoArticulo);
    }
}
