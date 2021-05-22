using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public abstract class BaseServiceImpl<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> tEntityRepository;

        public BaseServiceImpl(IBaseRepository<TEntity> tEntityRepository){

            this.tEntityRepository = tEntityRepository;
        }

        public TEntity ObtenerPorId(int id)
        {
            TEntity entity = tEntityRepository.ObtenerPorId(id);
            return entity;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = tEntityRepository.ObtenerTodos();
            return listEntity;
        }

        public void Insertar(TEntity entity)
        {
            tEntityRepository.Insertar(entity);
        }

        public void Actualizar(TEntity entity)
        {
            tEntityRepository.Actualizar(entity);
        }

        public void Eliminar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            tEntityRepository.EliminarPorId(id);
        }





    }
}
