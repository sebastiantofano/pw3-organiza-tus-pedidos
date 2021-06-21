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
        [StringLength(8, ErrorMessage = "El código no puede tener más de 8 caractéres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe introducir obligatoriamente una descripción del artículo")]
        [StringLength(50, ErrorMessage = "La descripción no puede tener más de 50 caractéres")]
        public string Descripcion { get; set; }

    }

    public class UsuarioMetadata
    {
        [Required(ErrorMessage = "Debe ingresar un obligatoriamente un email")]
        [EmailAddress(ErrorMessage = "Ingrese un formato de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar obligatoriamente una contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe completar este campo obligatoriamente")]
        public bool EsAdmin { get; set; }

        [Required(ErrorMessage = "Debe ingresar obligatoriamente un nombre")]
        public string Nombre { get; set; }
    }

    public class ClienteMetadata
    {
        [Required(ErrorMessage = "Debe ingresar obligatoriamente un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un obligatoriamente un email")]
        [EmailAddress(ErrorMessage = "Ingrese un formato de email válido")]
        public string Email { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Numero { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Cuit { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }
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
