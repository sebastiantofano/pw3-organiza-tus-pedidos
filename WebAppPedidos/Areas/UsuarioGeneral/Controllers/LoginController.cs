﻿using Microsoft.AspNetCore.Mvc;
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

using System.Security.Principal;
using System.Web;
using Servicios.Helpers;
using Microsoft.AspNetCore.Http;

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

        [Route("Login")]
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
                    Usuario usuarioValidado = loginService.IniciarSesion(usuario);
                    //var token = TokenService.CreateToken(usuarioValidado);
                    //HttpContext.Session.SetString("token", token);

                    if (usuarioValidado.EsAdmin)
                    {
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
            TempData["toastr_error"] = "Debe ingresar sus credenciales correctamente";
            return RedirectToAction("Index", "Login", new { Area = "UsuarioGeneral" });

        }
    }
}
