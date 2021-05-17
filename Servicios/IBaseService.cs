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
        void Insertar(TEntity dataObject);
        void Actualizar(TEntity dataObject);
        void Eliminar(TEntity dataObject);
        void EliminarPorId(int id);

    }
}
