using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.DAO.Interfaces
{
    public interface IArticulosDAO : IDAO<Articulo>
    {
        bool ValidarCodigoExistente(string codigo);
    }
}
