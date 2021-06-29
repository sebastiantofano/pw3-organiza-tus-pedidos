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
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper; 

        public ClientesController(IClientesService clientesService, IMapper mapper)
        {
            _clientesService = clientesService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            List<Cliente> clientes = _clientesService.ObtenerTodos();
            List<ClienteResponse> clientesResponse = new();
            foreach (Cliente cliente in clientes)
            {
                ClienteResponse clienteResponse = _mapper.Map<ClienteResponse>(cliente);
                clientesResponse.Add(clienteResponse);
            }
            return new {
                count = clientesResponse.Count,
                clientes = clientesResponse
            };
        }

        [HttpPost]
        public ActionResult<dynamic> Filtrar([FromBody] FiltroRequest filtroRequest)
        {
            List<Cliente> clientes = _clientesService.FiltrarPorNombre(filtroRequest?.Filtro);
            List<ClienteResponse> clientesResponse = new();
            foreach (Cliente cliente in clientes)
            {
                ClienteResponse clienteResponse = _mapper.Map<ClienteResponse>(cliente);
                clientesResponse.Add(clienteResponse);
            }
            return new {
                count = clientesResponse.Count,
                clientes = clientesResponse
            };
        }
    }
}
