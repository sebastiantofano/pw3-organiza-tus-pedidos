using ModeloDatosProvisorios.Datos.Datos;
using ModeloDatosProvisorios.Datos.Datos.Interfaces;
using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class ArticulosRepositoryImpl : BaseRepositoryImpl<Articulo>, IArticulosRepository
    {
        public ArticulosRepositoryImpl() : base(new ArticulosDatos())
        {
        }

    }
}
