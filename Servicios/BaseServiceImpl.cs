using DAL.Modelos.Interfaces;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Helpers.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public abstract class BaseServiceImpl<TEntity> : IBaseService<TEntity> where TEntity : class, ITrackeableEntity
    {
        private readonly IBaseRepository<TEntity> _entityRepository;

        public BaseServiceImpl(IBaseRepository<TEntity> entityRepository)
        {

            _entityRepository = entityRepository;
        }

        public TEntity ObtenerPorId(int id)
        {
            TEntity entity = _entityRepository.ObtenerPorId(id);
            return entity;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = _entityRepository.ObtenerTodos();
            return listEntity;
        }

        /* Este método es "Virtual" porque puede ser sobrescrito para agregar logica en los servicios particulares */
        public virtual void Insertar(TEntity entity)
        {
            entity.FechaCreacion = DateTime.Today;
            _entityRepository.Insertar(entity);
        }

        /* Este método es "Virtual" porque puede ser sobrescrito para agregar logica en los servicios particulares */
        public virtual void Actualizar(TEntity entity)
        {
            entity.FechaModificacion = DateTime.Today;
            _entityRepository.Actualizar(entity);
        }

        public void Eliminar(TEntity entity)
        {
            _entityRepository.Eliminar(entity);
        }

        public void EliminarPorId(int id, string who)
        {
            _entityRepository.EliminarPorId(id, who);
        }





    }
}
