﻿
using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral.Interfaces
{
    public interface ILoginService
    {
        Usuario IniciarSesion(Usuario usuario);
        void CerrarSesion();


    }
}
