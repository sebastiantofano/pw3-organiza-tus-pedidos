using DAL.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> Get()
        {
            List<Cliente> clientes = _clientesService.ObtenerTodos();
            return new {
                count = clientes.Count,
                clientes = clientes //TODO: Modificar esto por el cliente response , ¿Hacer un mapper?
            };
        }
    }
}
