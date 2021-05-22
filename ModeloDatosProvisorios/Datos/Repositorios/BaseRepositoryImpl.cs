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
        private readonly IDatos<TEntity> tEntityDatos;

        public BaseRepositoryImpl(IDatos<TEntity> tEntityDatos)
        {
            this.tEntityDatos = tEntityDatos;
        }

        /*Estos metodos luego van a cambiar por las consultas a la base de datos, es decir, llamarán a una sesión y harán la logica
             puede que algunos sean virtuales y se tengan que sobrescribir en las implementaciones particulares ya que puede tener diferentes logicas*/
        public TEntity ObtenerPorId(int id)
        {
            return tEntityDatos.ObtenerPorId(id);
        }
        public List<TEntity> ObtenerTodos()
        {
            return tEntityDatos.ObtenerTodos();
        }
        public void Actualizar(TEntity entity)
        {
            tEntityDatos.Actualizar(entity);
        }
        public void Insertar(TEntity entity)
        {
            tEntityDatos.Insertar(entity);
        }
        public void EliminarPorId(int id)
        {
            tEntityDatos.EliminarPorId(id);
        }
        public void Eliminar(TEntity entity)
        {
            tEntityDatos.Eliminar(entity);
        }
    }
}
