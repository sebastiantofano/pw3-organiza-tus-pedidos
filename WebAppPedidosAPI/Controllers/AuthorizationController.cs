using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Helpers.Exceptions;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using Servicios.Helpers;
using Servicios.UsuarioGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using WebAppPedidosAPI.ResponseObjects;

namespace WebAppPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly ILoginService loginService;


        public AuthorizationController()
        {
            loginService = new LoginServiceImpl(new LoginRepositoryImpl(new UsuariosDAOImpl()));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Usuario usuarioValidar)
        {
            try
            {
                Usuario usuarioValidado = loginService.IniciarSesion(usuarioValidar);
                var token = TokenService.CreateToken(usuarioValidado);
                UsuarioLogueadoResponse usuarioLogueadoResponse = new(usuarioValidado.IdUsuario, usuarioValidado.Nombre,
                                                                      usuarioValidado.Apellido, usuarioValidado.FechaNacimiento);
                // Devuelvo un JSON con los datos del usuario y el JWT
                return new {
                    usuario = usuarioLogueadoResponse,
                    token = token
                };
            }
            catch (InvalidLoginException)
            {
                return new {
                    usuario = false,
                    token = false
                };
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("You are Authenticated - {0}", User.Identity.Name);

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "Administrador")]
        public string Admin()
        {
            return $"You are a Administrador - {User.Identity.Name}";
        }

        [HttpGet]
        [Route("validar")]
        [Authorize(Roles = "Administrador")]
        public string Validar(string id)
        {


            return $"You are a Administrador - {User.Identity.Name}";
        }

    }
}
