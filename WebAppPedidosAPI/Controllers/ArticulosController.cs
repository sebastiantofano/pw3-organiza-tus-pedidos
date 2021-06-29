using AutoMapper;
using DAL.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.RequestObjects;
using WebAPI.ResponseObjects;

namespace WebAPI.Controllers
{
    //TODO: Falta agregar la autorizacion
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosService _articulosService;
        private readonly IMapper _mapper; 

        public ArticulosController(IArticulosService articulosService, IMapper mapper)
        {
            _articulosService = articulosService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            List<Articulo> articulos = _articulosService.ObtenerTodos();
            List<ArticuloResponse> articulosResponse = new();
            foreach (Articulo articulo in articulos)
            {
                ArticuloResponse articuloResponse = _mapper.Map<ArticuloResponse>(articulo);
                articulosResponse.Add(articuloResponse);
            }
            return new {
                count = articulosResponse.Count,
                articulos = articulosResponse
            };
        }

        [HttpPost]
        [Route("filtrar")]
        public ActionResult<dynamic> Filtrar([FromBody] FiltroRequest filtroRequest)
        {
            List<Articulo> articulos = _articulosService.FiltrarPorDescripcion(filtroRequest?.Filtro);
            List<ArticuloResponse> articulosResponse = new();
            foreach (Articulo articulo in articulos)
            {
                ArticuloResponse articuloResponse = _mapper.Map<ArticuloResponse>(articulo);
                articulosResponse.Add(articuloResponse);
            }
            return new {
                count = articulosResponse.Count,
                articulos = articulosResponse
            };
        }
    }
}
