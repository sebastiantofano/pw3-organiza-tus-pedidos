using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.RequestObjects
{
    public class UsuarioLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
