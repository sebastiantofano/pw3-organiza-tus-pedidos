using ModeloDatosProvisorios.Datos;
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
        public IAccesoDatos<TEntity> Datos { get; set; }

        public BaseServiceImpl(IAccesoDatos<TEntity> entity){

            Datos = entity;
        }

        public TEntity ObtenerPorId(int id)
        {
            TEntity entity = Datos.ObtenerPorId(id);
            return entity;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = Datos.ObtenerTodos();
            return listEntity;
        }

        public void Insertar(TEntity entity)
        {
            Datos.Insertar(entity);
        }

        public void Actualizar(TEntity entity)
        {
            Datos.Actualizar(entity);
        }

        public void Eliminar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            Datos.EliminarPorId(id);
        }





    }
}
