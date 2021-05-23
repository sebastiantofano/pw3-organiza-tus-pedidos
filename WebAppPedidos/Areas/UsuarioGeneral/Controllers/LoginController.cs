using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.Helpers.Exceptions;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
    public class LoginController : Controller

    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService) // Luego tendremos inyeccion de dependencias
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IniciarSesion(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    loginService.IniciarSesion(usuario);
                    return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
                }
                catch (InvalidLoginException)
                {

                    TempData["toastr_error"] = "ERROR AL INICIAR SESION CAMBIAR ESTO";
                    return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
                }
            }
            return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });

        }
    }
}
