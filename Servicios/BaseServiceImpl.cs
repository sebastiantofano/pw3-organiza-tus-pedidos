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
    public abstract class BaseServiceImpl<TEntity> : IBaseService<TEntity> where TEntity : class, IIdentificableEntity, IAuditableEntity
    {
        private readonly IBaseRepository<TEntity> _entityRepository;
        readonly protected IHttpContextAccessor _httpContextAccessor;


        public BaseServiceImpl(IBaseRepository<TEntity> entityRepository, IHttpContextAccessor httpContextAccessor)
        {
            _entityRepository = entityRepository;
            _httpContextAccessor = httpContextAccessor;
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
        public virtual int Insertar(TEntity entity)
        {
            string idUsuario = _httpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            entity.CreadoPor = int.Parse(idUsuario);
            entity.FechaCreacion = DateTime.Today;
            return _entityRepository.Insertar(entity);
        }

        /* Este método es "Virtual" porque puede ser sobrescrito para agregar logica en los servicios particulares */
        public virtual void Actualizar(TEntity entity)
        {
            string idUsuario = _httpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            entity.ModificadoPor = int.Parse(idUsuario);
            entity.FechaModificacion = DateTime.Today;

            _entityRepository.Actualizar(entity);
        }

        /* Clase encargada de la logica de negocio del borrado logico, sera quien sepa QUE valores actualizar*/
        public void Eliminar(TEntity entity)
        {
            string idUsuario = _httpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            entity.BorradoPor = int.Parse(idUsuario);
            entity.FechaBorrado = DateTime.Today;

            _entityRepository.Eliminar(entity);
        }






    }
}
