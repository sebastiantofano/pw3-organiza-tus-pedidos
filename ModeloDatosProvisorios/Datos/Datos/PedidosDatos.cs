﻿using ModeloDatosProvisorios.Datos.Datos.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Datos
{
    /* Esta clase simula ser una tabla de la base de datos */
    public class PedidosDatos : IDatos<Pedido>
    {
        public void Actualizar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public Pedido ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
