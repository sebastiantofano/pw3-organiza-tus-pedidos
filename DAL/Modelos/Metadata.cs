using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelos
{
    public class ArticuloMetadata
    {
        [Required(ErrorMessage = "Debe introducir obligatoriamente un código de artículo")]
        [StringLength(8, ErrorMessage = "El código no puede tener más de 8 caractéres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una descripción del artículo")]
        [StringLength(50, ErrorMessage = "La descripción no puede tener más de 50 caractéres")]
        public string Descripcion { get; set; }

    }



}
