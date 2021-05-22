using ModeloDatosProvisorios.Datos.Datos;
using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class ClientesRepositoryImpl : BaseRepositoryImpl<Cliente>, IClientesRepository
    {
        public ClientesRepositoryImpl():base(new ClientesDatos())
        {

        }


    }
}
