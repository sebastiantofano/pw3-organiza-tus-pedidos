using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios
{
    public class PedidosRepositoryImpl : BaseRepositoryImpl<Pedido> , IPedidosRepository
    {
        private readonly IPedidosDAO pedidosDAO; 
        public PedidosRepositoryImpl(IPedidosDAO pedidosDAO) : base(pedidosDAO)
        {
            this.pedidosDAO = pedidosDAO;
        }
    }
}
