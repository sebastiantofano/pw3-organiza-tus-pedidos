using ModeloDatosProvisorios.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDatosProvisorios.Repositorios;
using ModeloDatosProvisorios.DAO;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class ArticulosRepositoryImpl : BaseRepositoryImpl<Articulo>, IArticulosRepository
    {
        
        public ArticulosRepositoryImpl() : base(new ArticulosDAOImpl())
        {
        }

    }
}
