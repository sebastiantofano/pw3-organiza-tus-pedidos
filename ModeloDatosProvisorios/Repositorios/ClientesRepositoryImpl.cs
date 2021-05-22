﻿using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.DAO.Interfaces;
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
        private readonly IClientesDAO clientesDAO;
        public ClientesRepositoryImpl(IClientesDAO clientesDAO):base(clientesDAO)
        {
            this.clientesDAO = clientesDAO;
        }


    }
}
