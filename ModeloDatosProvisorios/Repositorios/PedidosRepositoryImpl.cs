using ModeloDatosProvisorios.DAO;
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
        public PedidosRepositoryImpl() : base(new PedidosDaoImpl())
        {

        }
    }
}
