using DAL.Modelos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Namespace hardcodeado para poder utilizar partial classes y tener nuestras clases partials en otro directorio ordenadamente */
namespace DAL.Modelos
{
    
    [ModelMetadataType(typeof(ArticuloMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Articulo : IAuditableEntity // Debo implementar ItrackeableEntity porque lo utilizamos en BaseServiceImpl para manejar sus properties
    {

    }

    [ModelMetadataType(typeof(UsuarioMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Usuario : IAuditableEntity
    {
        [NotMapped] // Para que no se tenga en cuenta esta property en la base de datos, ya que es una propiedad logica de la aplicacion
        public string Roles {
            get {
                return EsAdmin ? "Administrador" : "Moderador";
            }
            set { }
        }

        [NotMapped]
        public string Token { get; set; }

    }

    [MetadataType(typeof(ClienteMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Cliente : IAuditableEntity
    {

    }

    [MetadataType(typeof(PedidoMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Pedido : IAuditableEntity
    {

    }

    [MetadataType(typeof(PedidoArticuloMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class PedidoArticulo
    {

    }

}
