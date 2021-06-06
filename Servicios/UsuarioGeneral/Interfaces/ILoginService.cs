
using DAL.Modelos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral.Interfaces
{
    public interface ILoginService
    {
        Usuario IniciarSesion(HttpContext httpContext, Usuario usuario);
        void CerrarSesion(HttpContext httpContext);


    }
}
