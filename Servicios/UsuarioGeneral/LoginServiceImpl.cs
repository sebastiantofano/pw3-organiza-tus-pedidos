using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Helpers.Exceptions;
using Servicios.Helpers.Security;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral
{
    public class LoginServiceImpl : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        private readonly SecurityManager _securityManager;
       

        public LoginServiceImpl(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
            _securityManager = new SecurityManager(); // Clase encargada de manejar Autentificacion y Autorizacion de la Web App
        }
        public void CerrarSesion(HttpContext httpContext)
        {
            _securityManager.SignOut(httpContext); //Agregar esta linea para eliminar los claims del usuario
        }

        public Usuario IniciarSesion(HttpContext httpContext, Usuario usuario)
        {
            try
            {
                Usuario usuarioEncontrado = loginRepository.IniciarSesion(usuario);
                usuarioEncontrado.Token = TokenService.CreateToken(usuarioEncontrado); // Eso sera de ayuda cuando se inicie la APP en modo API
                _securityManager.SignIn(httpContext, usuarioEncontrado); // Agrega los claims al usuario actual

                return usuarioEncontrado;
            }
            catch (LoginException)
            {
                throw;
            }
            
        }
    }
}
