﻿using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class ClientesRepositoryImpl : BaseRepositoryImpl<Cliente>, IClientesRepository
    {
        private readonly PedidosPW3Context _pedidosPW3Context;
        public ClientesRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }


    }
}
