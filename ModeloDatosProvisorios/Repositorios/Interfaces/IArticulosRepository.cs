using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios.Interfaces
{
    public interface IArticulosRepository : IBaseRepository<Articulo>
    {
        void AlgoParticularDelArticulo();
    }
}
