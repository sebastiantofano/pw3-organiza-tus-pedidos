﻿using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador.Interfaces
{
    public interface IClientesService : IBaseService<Cliente> // Esta interface hereda el CRUD de Servicio Base
    {
        bool ValidarEmailExistente(string email);
        List<Cliente> FiltrarPorNombre(string cadena);
        public List<Cliente> ObtenerTodosOrdenAnalfabetico();
        bool ValidarNumeroExistente(int numero);

    }
}
