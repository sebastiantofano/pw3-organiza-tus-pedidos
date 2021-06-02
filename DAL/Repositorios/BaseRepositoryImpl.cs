using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public abstract class BaseRepositoryImpl<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly PedidosPW3Context pedidosPW3Context;

        public BaseRepositoryImpl()
        {
            pedidosPW3Context = new PedidosPW3Context();
        }


        public TEntity ObtenerPorId(int id)
        {
            return pedidosPW3Context.Find<TEntity>(id);
        }
        public List<TEntity> ObtenerTodos()
        {
            return new();
        }
        public void Actualizar(TEntity entity)
        {

        }
        public void Insertar(TEntity entity)
        {

        }
        public void EliminarPorId(int id, string who)
        {

        }
        public void Eliminar(TEntity entity)
        {

        }
    }
}
