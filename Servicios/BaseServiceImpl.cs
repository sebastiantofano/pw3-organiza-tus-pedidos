using ModeloDatosProvisorios.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public abstract class BaseServiceImpl<TEntity> : IBaseService<TEntity> where TEntity : new()
    {
        public TEntity ObtenerPorId(int id)
        {
            TEntity entity = new();
            return entity;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = (List<TEntity>) Convert.ChangeType(ArticulosDatos.listaArticulos, typeof(List<TEntity>));
            return listEntity;
        }
        public void Actualizar(TEntity dataObject)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(TEntity dataObject)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(TEntity dataObject)
        {
            throw new NotImplementedException();
        }




    }
}
