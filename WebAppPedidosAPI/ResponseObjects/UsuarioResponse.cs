using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ResponseObjects
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public UsuarioResponse(int idUsuario, string email, string nombre, string apellido, DateTime fechaNacimiento)
        {
            IdUsuario = idUsuario;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
