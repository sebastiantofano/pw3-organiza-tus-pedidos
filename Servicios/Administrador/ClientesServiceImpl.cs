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
    public class ClientesServiceImpl : BaseServiceImpl<Cliente>, IClientesService
    {
        private readonly IClientesRepository clientesRepository;
        public ClientesServiceImpl(IClientesRepository clientesRepository) : base(clientesRepository) // Hago el NEW porque todavia no vimos inyeccion de dependencias
        {
            this.clientesRepository = clientesRepository;
        }

        
    }
}
