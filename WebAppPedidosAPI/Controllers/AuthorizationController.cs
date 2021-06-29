﻿using DAL.Modelos;
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
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILoginService _loginService;


        public AuthorizationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> IniciarSesion([FromBody] Usuario usuarioValidar)
        {
            try
            {
                Usuario usuarioValidado = _loginService.IniciarSesion(HttpContext, usuarioValidar);
                //var token = TokenService.CreateToken(usuarioValidado);
                UsuarioLogueadoResponse usuarioLogueadoResponse = new(usuarioValidado.IdUsuario, usuarioValidado.Nombre,
                                                                      usuarioValidado.Apellido, usuarioValidado.FechaNacimiento);
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
        public async Task<ActionResult<dynamic>> CerrarSesion([FromBody] Usuario usuarioValidar)
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

        [HttpGet]
        [Route("validar")]
        [Authorize(Roles = "Administrador")]
        public string Validar(string id)
        {
            return $"You are a Administrador - {User.Identity.Name}";
        }

    }
}
