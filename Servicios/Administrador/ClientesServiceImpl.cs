using ModeloDatosProvisorios.Datos.Repositorios;
using ModeloDatosProvisorios.Modelos;
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
        public ClientesServiceImpl() : base(new ClientesRepositoryImpl()) // Hago el NEW porque todavia no vimos inyeccion de dependencias
        {
        }
    }
}
