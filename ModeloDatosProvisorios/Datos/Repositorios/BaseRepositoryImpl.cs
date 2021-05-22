using ModeloDatosProvisorios.Datos.Datos.Interfaces;
using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class BaseRepositoryImpl<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        // Simula ser la sesion a la base de datos
        public IDatos<TEntity> Datos;

        public BaseRepositoryImpl(IDatos<TEntity> Datos)
        {
            this.Datos = Datos;
        }

        /*Estos metodos luego van a cambiar por las consultas a la base de datos,
             puede que algunos sean virtuales y se tengan que sobrescribir en las implementaciones particulares*/
        public TEntity ObtenerPorId(int id)
        {
            return Datos.ObtenerPorId(id);
        }
        public List<TEntity> ObtenerTodos()
        {
            return Datos.ObtenerTodos();
        }
        public void Actualizar(TEntity entity)
        {
            Datos.Actualizar(entity);
        }
        public void Insertar(TEntity entity)
        {
            Datos.Insertar(entity);
        }
        public void EliminarPorId(int id)
        {
            Datos.EliminarPorId(id);
        }
        public void Eliminar(TEntity entity)
        {
            Datos.Eliminar(entity);
        }
    }
}
