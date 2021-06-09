using DAL.Modelos;
using DAL.Modelos.Interfaces;
using DAL.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public abstract class BaseRepositoryImpl<TEntity> : IBaseRepository<TEntity> where TEntity : class, IAuditableEntity
    {

        private readonly PedidosPW3Context _pedidosPW3Context;
        private readonly DbSet<TEntity> _dbSet; // Atributo para manejar un DbSet en particular

        public BaseRepositoryImpl(PedidosPW3Context pedidosPW3Context) // IoC proveniente de quien extienda de esta clase y lo deba enviar como parametro
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

        public void Insertar(TEntity entity)
        {
            _pedidosPW3Context.Add(entity);
            _pedidosPW3Context.SaveChanges();
        }

        public virtual void Actualizar(TEntity entity)
        {
            _pedidosPW3Context.Set<TEntity>().Update(entity);
            _pedidosPW3Context.SaveChanges();
        }

        /* Borrado logico, este metodo solo tendra la responsabilidad de actualizar las propiedades. 
            No es el encargado de la logica sino que es el servicio*/
        public void Eliminar(TEntity entity)
        {

            // Pasa de estar en estado Detached a Unchanged
            _pedidosPW3Context.Set<TEntity>().Attach(entity);

            //Specify the fields that should be updated.
            _pedidosPW3Context.Entry(entity).Property(x => x.BorradoPor).IsModified = true;
            _pedidosPW3Context.Entry(entity).Property(x => x.FechaBorrado).IsModified = true;

            _pedidosPW3Context.SaveChanges();
        }

    }
}
