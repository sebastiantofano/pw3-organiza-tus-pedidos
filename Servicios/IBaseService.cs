using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IBaseService<TEntity>  
    {
        TEntity ObtenerPorId(int id);
        List<TEntity> ObtenerTodos();
        void Insertar(TEntity entity);
        void Actualizar(TEntity entity);
        void Eliminar(TEntity entity);
        void EliminarPorId(int id);

    }
}
