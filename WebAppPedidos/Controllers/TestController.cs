using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios;
using Servicios.Administrador;
using Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("TestToken")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario usuario)
        {
            UsuariosServiceImpl usuariosService = new UsuariosServiceImpl(new UsuariosRepositoryImpl(new UsuariosDAOImpl())); 
            var userEncontrado = usuariosService.ObtenerPorId(usuario.IdUsuario);

            if (userEncontrado == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(userEncontrado);
            userEncontrado.Password = "";
            return new {
                user = userEncontrado,
                token = token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated - {0}", User.Identity.Name);


        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous()
        {
            return "You are Anonymous";
        }



        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "Administrador")]
        public string admin()
        {
            return "You are a Administrador";
        }
    }
}
