using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Datos.Interfaces
{   
    /* Esta interfaz simula ser la base de datos*/
    public interface IDatos<TEntity>
    {
        TEntity ObtenerPorId(int id); // Simula ser: SELECT * FROM TEntityTable WHERE TEntityId = id  
        List<TEntity> ObtenerTodos(); // Simula ser: SELECT * FROM TEntityTable
        void Insertar(TEntity entity); // Simula ser: INSERT INTO TEntityTable (TEntityProps) VALUES (entityProps)
        void Actualizar(TEntity entity); // Simula ser: UPDATE TEntityTable SET TEntityProps = entityProps WHERE TEntityObject = entityObject
        void Eliminar(TEntity entity); // Simula ser: DELETE FROM TEntity WHERE TEntityObject = entityObject 
        void EliminarPorId(int id); // Simula ser: DELETE FROM TEntityTable WHERE TEntityId = id
    }
}
