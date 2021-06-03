using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorios.Interfaces;
using DAL.Modelos;

namespace DAL.Repositorios
{
    public class ArticulosRepositoryImpl : BaseRepositoryImpl<Articulo>, IArticulosRepository
    {
        private readonly PedidosPW3Context _pedidosPW3Context;

        public ArticulosRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }

        public void AlgoParticularDelArticulo()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCodigoExistente(string codigo)
        {
            Articulo articuloExistente = _pedidosPW3Context.Articulos.Where(o => o.Codigo == codigo).FirstOrDefault();
            if(articuloExistente == null)
            {
                return false;
            }

            return true;
        }
    }
}
