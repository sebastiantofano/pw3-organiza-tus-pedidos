using ModeloDatosProvisorios.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos
{
    public class Usuario : BaseEntity, ITrackeableEntity
    {
        public int IdUsuario {
            get {
                return base.Id;
            }
            set {
                base.Id = value;
            }
        }

        public bool EsAdmin { get; set; }


        [Required(ErrorMessage = "Debe introducir obligatoriamente un email de usuario")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una contraseña de usuario")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente el nombre del usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente el apellido del usuario")]
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaUltimoLogin { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.Today;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }


        public string Roles {
            get {
                return EsAdmin ? "Administrador" : "Moderador";
            }
            set { }
        }

        

    }
}
