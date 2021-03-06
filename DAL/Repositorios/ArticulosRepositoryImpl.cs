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

        public bool ValidarCodigoExistente(string codigo)
        {
            Articulo articuloExistente = _pedidosPW3Context.Articulos.Where(o => o.Codigo == codigo).FirstOrDefault();
            return articuloExistente != null ? true : false;
        }

        public override void Actualizar(Articulo articulo)
        {
            // Pasa de estar en estado Detached a Unchanged
            _pedidosPW3Context.Set<Articulo>().Attach(articulo);

            //Specify the fields that should be updated.
            _pedidosPW3Context.Entry(articulo).Property(x => x.Codigo).IsModified = true;
            _pedidosPW3Context.Entry(articulo).Property(x => x.Descripcion).IsModified = true;
            _pedidosPW3Context.Entry(articulo).Property(x => x.ModificadoPor).IsModified = true;
            _pedidosPW3Context.Entry(articulo).Property(x => x.FechaModificacion).IsModified = true;

            _pedidosPW3Context.SaveChanges();
        }

        public List<Articulo> FiltrarPorDescripcion(string cadena)
        {
            IQueryable<Articulo> matches = from a in _pedidosPW3Context.Articulos
                                          where a.Descripcion.Contains(cadena)
                                          select a;

            return matches.ToList();
        }
    }
}
