using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class ArticulosRepositoryImpl : BaseRepositoryImpl<Articulo>, IArticulosRepository
    {

        public void AlgoParticularDelArticulo()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCodigoExistente(string codigo)
        {
            return true;
        }
    }
}
