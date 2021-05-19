using ModeloDatosProvisorios.Datos;
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
        public ClientesServiceImpl() : base(new ClientesAccesoDatos()) // Hago el new porque no tengo inyeccion de dependencias
        {
        }
    }
}
