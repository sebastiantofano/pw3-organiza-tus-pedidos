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

        private readonly PedidosPW3Context _pedidosPW3Context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepositoryImpl(PedidosPW3Context pedidosPW3Context) // IoC proveniente de quien extienda de esta clase
        {
            _pedidosPW3Context = pedidosPW3Context;
            _dbSet = pedidosPW3Context.Set<TEntity>();
        }


        public TEntity ObtenerPorId(int id)
        {
            return _pedidosPW3Context.Find<TEntity>(id);
        }

        public List<TEntity> ObtenerTodos()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Actualizar(TEntity entity)
        {
            _pedidosPW3Context.Set<TEntity>().Update(entity);
            _pedidosPW3Context.SaveChanges();
        }

        public void Insertar(TEntity entity)
        {
            _pedidosPW3Context.Add(entity);
            _pedidosPW3Context.SaveChanges();
        }

        public void EliminarPorId(int id, string who)
        {
            //Este metodo no funciona debemos arreglarlo, falla por el tema de las referencias hacia otras tablas
            _dbSet.Remove(ObtenerPorId(id));
            _pedidosPW3Context.SaveChanges();
        }

        public void Eliminar(TEntity entity)
        {
            //Este metodo no funciona debemos arreglarlo, falla por el tema de las referencias hacia otras tablas
            _pedidosPW3Context.Remove<TEntity>(entity);
            _pedidosPW3Context.SaveChanges();
        }

    }
}
