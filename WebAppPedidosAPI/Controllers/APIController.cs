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

namespace WebAppPedidosAPI.Controllers
{
    [Route("api/v1")]
    public class APIController : Controller
    {
        private readonly ILoginService loginService;


        public APIController()
        {
            this.loginService = new LoginServiceImpl(new LoginRepositoryImpl(new UsuariosDAOImpl()));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Usuario usuario)
        {
            try
            {
                Usuario usuarioValidado = loginService.IniciarSesion(usuario);
                var token = TokenService.CreateToken(usuarioValidado);
                Usuario usuarioAPI = new();
                usuarioAPI.IdUsuario = usuarioValidado.IdUsuario;
                usuarioAPI.Nombre = usuarioValidado.Nombre;
                usuarioAPI.Apellido = usuarioValidado.Apellido;
                usuarioAPI.FechaNacimiento = usuarioValidado.FechaNacimiento;

                // Devuelvo un JSON con los datos del usuario y el JWT
                return new {
                    usuario = usuarioAPI,
                    token = token
                };
             

            }
            catch (InvalidLoginException)
            {

                return new {
                    usuario = false
                };
            }
        }
           


        
    }
}
