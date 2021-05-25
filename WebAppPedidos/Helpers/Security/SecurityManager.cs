﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAppPedidos.Helpers.Security
{
    public class SecurityManager
    {
        /* Metodo para la autenticacion */
        public async void SignIn(HttpContext httpContext, Usuario usuario)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(usuario), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        /* Metodo para la desautenticacion */
        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        /* Metodo para obtener los claims del usuario */
        private IEnumerable<Claim> getUserClaims(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Name, usuario.Email));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim(ClaimTypes.Role, usuario.Roles));
            return claims;
        }
    }
}
