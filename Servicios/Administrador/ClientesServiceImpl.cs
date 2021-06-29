using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class ClientesServiceImpl : BaseServiceImpl<Cliente>, IClientesService
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesServiceImpl(IClientesRepository clientesRepository, IHttpContextAccessor httpContextAccessor) : base(clientesRepository, httpContextAccessor)
        {
            _clientesRepository = clientesRepository;
        }

        public List<Cliente> FiltrarPorNombre(string cadena)
        {
            return _clientesRepository.FiltrarPorNombre(cadena);
        }
    }
}
