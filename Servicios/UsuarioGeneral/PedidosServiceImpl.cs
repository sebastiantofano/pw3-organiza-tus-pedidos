﻿using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral
{
    public class PedidosServiceImpl : BaseServiceImpl<Pedido>
    {
        public PedidosServiceImpl(IDatos<Pedido> entity) : base(entity)
        {
        }
    }
}
