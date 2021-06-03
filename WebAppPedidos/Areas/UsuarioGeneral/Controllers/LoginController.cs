using Microsoft.AspNetCore.Mvc;
using Servicios.UsuarioGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Servicios.Helpers;
using WebAppPedidos.Helpers.Security;
using Microsoft.AspNetCore.Authorization;
using DAL.Helpers.Exceptions;
using Servicios.UsuarioGeneral.Interfaces;
using DAL.Repositorios;
using DAL.Modelos;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
    public class LoginController : Controller

    {
        private readonly ILoginService _loginService;
        private readonly SecurityManager _securityManager;

        public LoginController(ILoginService loginService) // IoC en StartUp.cs
        {
            _loginService = loginService;

            /*Utilizado para implementar la seguridad*/
            _securityManager = new SecurityManager();
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
                    Usuario usuarioValidado = _loginService.IniciarSesion(usuario);
                    var token = TokenService.CreateToken(usuarioValidado);
                    _securityManager.SignIn(HttpContext, usuarioValidado);

                if (usuarioValidado.EsAdmin)
                    {
                    
                    //HttpContext.Session.SetString("NombreUsuario", usuarioValidado.Nombre.ToString());
                    //HttpContext.Session.SetString("ApellidoUsuario", usuarioValidado.Apellido.ToString());
                    TempData["toastr_success"] = $"Bienvenido {usuarioValidado.Nombre} (Usted es Administrador)";

                        return RedirectToAction("Index", "Home", new { Area = "Administrador" });
                    }
                    else
                    { 
                        TempData["toastr_success"] = $"Bienvenido {usuarioValidado.Nombre} (Usted es Moderador)";
                        return RedirectToAction("Index", "Home", new { Area = "Moderador" });
                    }
                    
                }
                catch (InvalidLoginException)
                {

                    TempData["toastr_error"] = "Credenciales Inválidas";
                    return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
                }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Moderador")]
        public IActionResult CerrarSesion()
        {
            _securityManager.SignOut(HttpContext); //Agregar esta linea para eliminar los claims del usuario
            TempData["toastr_success"] = "Ha cerrado su sesión correctamente!";
            return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
        }


    }
}
