using System;
using System.ComponentModel.DataAnnotations;

namespace ModeloDatosProvisorios.Modelos
{
    public class Articulo
    {
        
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente un código de artículo")]
        [StringLength(8, ErrorMessage = "El código no puede tener más de 8 caractéres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una descripción del artículo")]
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; private set; } = DateTime.Today;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadorPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }

    }
}
