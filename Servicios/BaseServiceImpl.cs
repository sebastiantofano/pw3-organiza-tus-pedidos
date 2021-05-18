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
        public IDatos<TEntity> Datos { get; set; }

        public BaseServiceImpl(IDatos<TEntity> entity){

            Datos = entity;
        }

        public TEntity ObtenerPorId(int id)
        {
            TEntity entityObject; 
            Type type = typeof(TEntity);
            if (type == typeof(Articulo)) 
            {
                List<Articulo> listadoArticulos = Datos.ListadoObjetos as List<Articulo>;
                entityObject = (TEntity) Convert.ChangeType(listadoArticulos.Find(i => i.IdArticulo == id), typeof(TEntity));
            }
            else
            {
                entityObject = null;
            }
     
            return entityObject;
        }
        public List<TEntity> ObtenerTodos()
        {
            List<TEntity> listEntity = (List<TEntity>) Convert.ChangeType(Datos.ListadoObjetos, typeof(List<TEntity>));
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
