using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Helpers.Exceptions;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using Servicios.Administrador.Interfaces;
using Servicios.UsuarioGeneral;
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
        public LoginController(/*ILoginService loginService*/) // Luego tendremos inyeccion de dependencias
        {
            //this.loginService = loginService;
            this.loginService = new LoginServiceImpl(new LoginRepositoryImpl(new UsuariosDAOImpl()));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    loginService.IniciarSesion(usuario);
                    return RedirectToAction("Index", "Home", new { Area = "Administrador" });
                }
                catch (InvalidLoginException)
                {

                    TempData["toastr_error"] = "Credenciales Inválidas";
                    return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });
                }
            }
            TempData["toastr_error"] = "Debe ingresar sus credenciales correctamente";
            return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });

        }
    }
}
