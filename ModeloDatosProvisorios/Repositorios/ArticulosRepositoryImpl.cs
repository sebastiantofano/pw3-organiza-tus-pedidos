using ModeloDatosProvisorios.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDatosProvisorios.Repositorios;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.DAO.Interfaces;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class ArticulosRepositoryImpl : BaseRepositoryImpl<Articulo>, IArticulosRepository
    {
        private readonly IArticulosDAO articulosDAO;

        public ArticulosRepositoryImpl(IArticulosDAO articulosDAO) : base(articulosDAO)
        {
            this.articulosDAO = articulosDAO;
        }

        public void AlgoParticularDelArticulo()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCodigoExistente(string codigo)
        {
            return articulosDAO.ValidarCodigoExistente(codigo);
        }
    }
}
