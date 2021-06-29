using AutoMapper;
using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Helpers;
using Servicios.Helpers.Exceptions;
using Servicios.Helpers.Security;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.RequestObjects;
using WebAPI.ResponseObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;


        public AuthorizationController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> IniciarSesion([FromBody] UsuarioLoginRequest usuarioLoginRequest)
        {
            try
            {
                Usuario usuarioValidacion = _mapper.Map<Usuario>(usuarioLoginRequest);
                Usuario usuarioValidado = _loginService.IniciarSesion(HttpContext, usuarioValidacion);
                UsuarioLogueadoResponse usuarioLogueadoResponse = _mapper.Map<UsuarioLogueadoResponse>(usuarioValidado);
                // Devuelvo un JSON con los datos del usuario y el JWT
                return new {
                    usuario = usuarioLogueadoResponse,
                    token = usuarioValidado.Token
                };
            }
            catch (LoginException)
            {
                return new {
                    usuario = false,
                    token = false
                };
            }


        }

        [HttpPost]
        [Route("logout")]
        [Authorize] // Solo puede cerrar sesion quien este autenticado
        public ActionResult<dynamic> CerrarSesion([FromBody] Usuario usuarioValidar)
        {
            _loginService.CerrarSesion(HttpContext);
            return new {
                mensaje = "Ha cerrado sesión exitosamente"
            };
        }


        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated()
        {
            return string.Format("You are Authenticated - {0}", User.Identity.Name);
        }

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "Administrador")]
        public string Admin()
        {
            return $"You are a Administrador - {User.Identity.Name}";
        }
    }
}
