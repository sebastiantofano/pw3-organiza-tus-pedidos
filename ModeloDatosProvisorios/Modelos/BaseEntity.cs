using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos
{
    /* Entidad compartida por todos los modelos del dominio */
    public class BaseEntity
    {
        [Required(ErrorMessage = "Id Requerido")]
        public int Id { get; set; }
    }
}
