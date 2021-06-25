using DAL.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IBaseService<TEntity> where TEntity : class, IIdentificableEntity, IAuditableEntity
    {
        TEntity ObtenerPorId(int id);
        List<TEntity> ObtenerTodos();
        int Insertar(TEntity entity);
        void Actualizar(TEntity entity);
        void Eliminar(TEntity entity);

        List<TEntity> ObtenerTodosNoEliminados();

    }
}
