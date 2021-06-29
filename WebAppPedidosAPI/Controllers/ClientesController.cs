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
using WebAPI.DTOs;

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
        public async Task<ActionResult<dynamic>> Get()
        {
            List<Cliente> clientes = _clientesService.ObtenerTodos();
            List<ClienteDTO> clientesDTOs = new();
            foreach(Cliente cliente in clientes)
            {
                ClienteDTO clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                clientesDTOs.Add(clienteDTO);
            }
            return new {
                count = clientesDTOs.Count,
                clientes = clientesDTOs
            };
        }
    }
}
