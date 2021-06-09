using Microsoft.AspNetCore.Mvc;
using Servicios.UsuarioGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Servicios.Helpers;
using Microsoft.AspNetCore.Authorization;
using Servicios.UsuarioGeneral.Interfaces;
using DAL.Repositorios;
using DAL.Modelos;
using Servicios.Helpers.Exceptions;
using Microsoft.AspNetCore.Http;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
    public class LoginController : Controller

    {
        private readonly ILoginService _loginService;


        public LoginController(ILoginService loginService) // IoC en StartUp.cs
        {
            _loginService = loginService;
        }

        [Route("~/")]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) // Si el usuario ya se encuentra autenticado no tiene que poder ver el login
            {
                if (User.IsInRole("Administrador"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Administrador" });
                }
                else if(User.IsInRole("Moderador"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Moderador" });
                }
                
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult IniciarSesion(Usuario usuario)
        {
            try
            {
                Usuario usuarioValidado = _loginService.IniciarSesion(HttpContext, usuario);

                HttpContext.Session.SetString("IdUsuario", usuarioValidado.IdUsuario.ToString());
                HttpContext.Session.SetString("NombreUsuario", usuarioValidado.Nombre.ToString());
                HttpContext.Session.SetString("ApellidoUsuario", usuarioValidado.Apellido.ToString());

                string rolUsuario = usuarioValidado.Roles.ToString();

                TempData["toastr_success"] = $"Bienvenido {usuarioValidado.Nombre} (Usted es {rolUsuario})";

                return RedirectToAction("Index", "Home", new { Area = rolUsuario });
            }
            catch (LoginException e)
            {
                TempData["toastr_error"] = e.Message;
                return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Moderador")]
        public IActionResult CerrarSesion()
        {
            _loginService.CerrarSesion(HttpContext);
            TempData["toastr_success"] = "Ha cerrado su sesión correctamente!";
            return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
        }


    }
}
