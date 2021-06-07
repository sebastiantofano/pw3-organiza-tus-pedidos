using DAL.Modelos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Security
{
    public class TokenService
    {
        private const double EXPIRE_HOURS = 1.0;
        public static string CreateToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()), // Claim donde guardamos ID del usuario
                    new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"), // Claim donde guardamos Nombre y Apellido del usuario
                    new Claim(ClaimTypes.Email, usuario.Email), // Claim donde guardamos Email del usuario
                    new Claim(ClaimTypes.Role, usuario.Roles), // Claim donde guardamos Rol del usuario TODO

        }),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
