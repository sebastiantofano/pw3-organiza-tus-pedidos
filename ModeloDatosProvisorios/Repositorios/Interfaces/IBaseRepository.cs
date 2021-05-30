using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        TEntity ObtenerPorId(int id);

        List<TEntity> ObtenerTodos();

        void Insertar(TEntity entity);

        void Actualizar(TEntity entity);

        void EliminarPorId(int id, string who);

        void Eliminar(TEntity entity);
    }
}
