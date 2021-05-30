using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios
{
    public abstract class BaseRepositoryImpl<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        
        private readonly IDAO<TEntity> tEntityDAO;

        public BaseRepositoryImpl(IDAO<TEntity> tEntityDAO)
        {
            this.tEntityDAO = tEntityDAO;
        }


        public TEntity ObtenerPorId(int id)
        {
            return tEntityDAO.ObtenerPorId(id);
        }
        public List<TEntity> ObtenerTodos()
        {
            return tEntityDAO.ObtenerTodos();
        }
        public void Actualizar(TEntity entity)
        {
            tEntityDAO.Actualizar(entity);
        }
        public void Insertar(TEntity entity)
        {
            tEntityDAO.Insertar(entity);
        }
        public void EliminarPorId(int id, string who)
        {
            tEntityDAO.EliminarPorId(id, who);
        }
        public void Eliminar(TEntity entity)
        {
            tEntityDAO.Eliminar(entity);
        }
    }
}
