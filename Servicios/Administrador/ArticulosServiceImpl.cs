using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class ArticulosServiceImpl : BaseServiceImpl<Articulo> , IArticulosService
    {
        
        private readonly IArticulosRepository articulosRepository;

        public ArticulosServiceImpl(IArticulosRepository articulosRepository) : base(articulosRepository)
        {
            this.articulosRepository = articulosRepository;
        }

        public void MetodoParticularDeArticulos(Articulo articulo)
        {
            articulosRepository.AlgoParticularDelArticulo();
        }

        public bool ValidarCodigoExistente(string codigo)
        {
            return articulosRepository.ValidarCodigoExistente(codigo);
        }
    }
}
