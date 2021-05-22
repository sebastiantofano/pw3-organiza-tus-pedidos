using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios
{
    public class ClientesRepositoryImpl : BaseRepositoryImpl<Cliente>, IClientesRepository
    {
        public ClientesRepositoryImpl():base(new ClientesDAOImpl())
        {

        }


    }
}
