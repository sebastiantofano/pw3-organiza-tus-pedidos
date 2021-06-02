using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<TEntity> dbSet;

        public BaseRepositoryImpl(PedidosPW3Context pedidosPW3Context)
        {
            this.pedidosPW3Context = pedidosPW3Context;
            this.dbSet = pedidosPW3Context.Set<TEntity>();
        }


        public TEntity ObtenerPorId(int id)
        {
            return pedidosPW3Context.Find<TEntity>(id);
        }
        public List<TEntity> ObtenerTodos()
        {
            return (List<TEntity>)dbSet.AsNoTracking();
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
