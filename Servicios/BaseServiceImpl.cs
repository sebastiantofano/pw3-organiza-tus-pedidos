using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public abstract class BaseServiceImpl<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> entityRepository;

        public BaseServiceImpl(IBaseRepository<TEntity> entityRepository){

            this.entityRepository = entityRepository;
        }

        public TEntity ObtenerPorId(int id)
        {
            TEntity entity = entityRepository.ObtenerPorId(id);
            return entity;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = entityRepository.ObtenerTodos();
            return listEntity;
        }

        public void Insertar(TEntity entity)
        {
            entityRepository.Insertar(entity);
        }

        public void Actualizar(TEntity entity)
        {
            entityRepository.Actualizar(entity);
        }

        public void Eliminar(TEntity entity)
        {
            entityRepository.Eliminar(entity);
        }

        public void EliminarPorId(int id)
        {
            entityRepository.EliminarPorId(id);
        }





    }
}
