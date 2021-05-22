﻿using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Datos.Repositorios;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
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

        //Constructor con inyeccion de dependencias
        /*public ArticulosServiceImpl(IArticulosRepository articulosRepository) : base(articulosRepository)
        {

        }*/
        public ArticulosServiceImpl(IArticulosRepository articulosRepository) : base(articulosRepository) // Hago el NEW porque todavia no vimos inyeccion de dependencias
        {
            this.articulosRepository = articulosRepository;
        }

        public void MetodoParticularDeArticulos(Articulo articulo)
        {
            articulosRepository.AlgoParticularDelArticulo();
        }
    }
}
