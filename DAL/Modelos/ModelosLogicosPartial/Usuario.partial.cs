using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Namespace hardcodeado para poder utilizar partial class y tener nuestras clases partial en otro directorio ordenadamente */
namespace DAL.Modelos
{
    public partial class Usuario
    {
        [NotMapped]
        public string Roles {
            get {
                return EsAdmin ? "Administrador" : "Moderador";
            }
            set { }
        }



    }
}
