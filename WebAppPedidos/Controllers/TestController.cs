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
            [Route("login")]
            public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
            {
                UsuariosServiceImpl usuariosService = new UsuariosServiceImpl(new UsuariosRepositoryImpl(new UsuariosDAOImpl())); 
                var user = usuariosService.ObtenerPorId(model.IdUsuario);

                if (user == null)
                    return NotFound(new { message = "User or password invalid" });

                var token = TokenService.CreateToken(user);
                user.Password = "";
                return new {
                    user = user,
                    token = token
                };
            }  
        
    }
}
