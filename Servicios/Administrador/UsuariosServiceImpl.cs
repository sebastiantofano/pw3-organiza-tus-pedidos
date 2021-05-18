﻿using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class UsuariosServiceImpl : BaseServiceImpl<Usuario>, IUsuariosServices
    {
        public UsuariosServiceImpl(IDatos<Usuario> entity) : base(entity)
        {
        }
    }
}
