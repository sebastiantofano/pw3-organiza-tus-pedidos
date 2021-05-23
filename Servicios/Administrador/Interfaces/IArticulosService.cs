﻿using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador.Interfaces
{
    public interface IArticulosService : IBaseService<Articulo>
    {
        void MetodoParticularDeArticulos(Articulo articulo);
        bool ValidarCodigoExistente(string codigo);
    }
}
