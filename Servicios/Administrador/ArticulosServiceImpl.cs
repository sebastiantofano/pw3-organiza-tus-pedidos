﻿using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class ArticulosServiceImpl : BaseServiceImpl<Articulo> , IArticulosService
    {
        
        private readonly IArticulosRepository _articulosRepository;


        public ArticulosServiceImpl(IArticulosRepository articulosRepository, IHttpContextAccessor httpContextAccessor) : base(articulosRepository, httpContextAccessor)
        {
            _articulosRepository = articulosRepository;
        }

        public List<Articulo> FiltrarPorDescripcion(string cadena)
        {
            return _articulosRepository.FiltrarPorDescripcion(cadena);
        }

        /* Sobrescribimos el metodo Insertar "Virtual" del Servicio Base ya que queremos agregar validaciones extras en la capa de Servicios */
        public override int Insertar(Articulo articulo)
        {
            articulo.Codigo = articulo.Codigo;
            bool codigoYaExistente = _articulosRepository.ValidarCodigoExistente(articulo.Codigo);
            if (codigoYaExistente)
            {
                throw new ArticuloException($"Ya existe un artículo con el código {articulo.Codigo}");
            }
            return base.Insertar(articulo);
        }

    }
}
