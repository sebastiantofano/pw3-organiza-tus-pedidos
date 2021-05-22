using ModeloDatosProvisorios.Datos.Repositorios;
using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
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
        //Constructor con inyeccion de dependencias
        /*public ArticulosServiceImpl(IArticulosRepository articulosRepository) : base(articulosRepository)
        {

        }*/
        public ArticulosServiceImpl() : base(new ArticulosRepositoryImpl()) // Hago el NEW porque todavia no vimos inyeccion de dependencias
        {

        }


    }
}
