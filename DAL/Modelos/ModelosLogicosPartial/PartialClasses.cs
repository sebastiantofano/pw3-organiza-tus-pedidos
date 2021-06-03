using DAL.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Namespace hardcodeado para poder utilizar partial class y tener nuestras clases partial en otro directorio ordenadamente */
namespace DAL.Modelos
{
   
    [MetadataType(typeof(ArticuloMetadata))]
    public partial class Articulo : ITrackeableEntity
    {

    }

    public partial class Usuario : ITrackeableEntity
    {
        [NotMapped]
        public string Roles {
            get {
                return EsAdmin ? "Administrador" : "Moderador";
            }
            set { }
        }

    }

    public partial class Cliente : ITrackeableEntity
    {

    }

    public partial class Pedido : ITrackeableEntity
    {

    }

}
