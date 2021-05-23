using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public bool EsAdmin { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaUltimoLogin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string CreadorPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }

        public string Roles { get; set; }
    }
}
