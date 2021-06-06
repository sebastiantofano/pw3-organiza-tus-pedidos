using DAL.Modelos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Security
{
    public class SecurityManager // Clase utilizada para manejar la autentificacion y autorizacion de la Web App
    {
        
        /* Metodo para la autenticacion */
        public async void SignIn(HttpContext httpContext, Usuario usuario)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaims(usuario), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        /* Metodo para la desautenticacion */
        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        /* Metodo para obtener los claims del usuario */
        private IEnumerable<Claim> GetUserClaims(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.PrimarySid, usuario.IdUsuario.ToString())); // Claim donde guardamos ID del usuario
            claims.Add(new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}")); // Claim donde guardamos Nombre y Apellido del usuario
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email)); // Claim donde guardamos Email del usuario
            claims.Add(new Claim(ClaimTypes.Role, usuario.Roles)); // Claim donde guardamos Rol del usuario TODO
            return claims;
        }
    }
}
