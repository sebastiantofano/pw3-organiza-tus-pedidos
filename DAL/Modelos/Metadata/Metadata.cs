using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* En este namespace encontramos todas las clases "Metadata" donde se realizarán las validaciones sobre los Data Models */
/* Las validaciones no se podrán hacer sobre las clases originales ya que se sobrescriben al inicializar el contexto nuevamente */
namespace DAL.Modelos
{

    public class ArticuloMetadata
    {
        [Required(ErrorMessage = "Debe introducir obligatoriamente un código de artículo")]
        [StringLength(10, ErrorMessage = "El código no puede tener más de 10 caractéres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una descripción del artículo")]
        [StringLength(30, ErrorMessage = "La descripción no puede tener más de 30 caractéres")]
        public string Descripcion { get; set; }

    }

    public class UsuarioMetadata
    {

    }

    public class ClienteMetadata
    {

    }

    public class PedidoMetadata
    {

    }

    public class PedidoArticuloMetadata
    {
        [Required]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "Debe seleccionar obligatoriamente un artículo")]
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una cantidad")]
        [RegularExpression("([1-9][0-9]*)")]
        public int Cantidad { get; set; }
    }
}
