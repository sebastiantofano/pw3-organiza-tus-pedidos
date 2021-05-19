using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public interface IAccesoDatos<TEntity>
    {
        TEntity ObtenerPorId(int id);

        List<TEntity> ObtenerTodos();

        void Insertar(TEntity entity);

        void Actualizar(TEntity entity);

        void EliminarPorId(int id);
    }
}
