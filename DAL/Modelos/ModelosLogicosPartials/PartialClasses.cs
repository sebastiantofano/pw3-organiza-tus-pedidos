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
    public partial class Articulo : IIdentificableEntity, IAuditableEntity // Debo implementar ItrackeableEntity porque lo utilizamos en BaseServiceImpl para manejar sus properties
    {
        [NotMapped] // Para que no se tenga en cuenta esta property en la base de datos, ya que es una propiedad logica de la aplicacion
        public int Id { get => IdArticulo; set => IdArticulo = value; }
    }

    [ModelMetadataType(typeof(UsuarioMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Usuario : IIdentificableEntity, IAuditableEntity
    {
        [NotMapped] // Para que no se tenga en cuenta esta property en la base de datos, ya que es una propiedad logica de la aplicacion
        public int Id { get => IdUsuario; set => IdUsuario = value; }


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
    public partial class Cliente : IIdentificableEntity, IAuditableEntity
    {
        [NotMapped] // Para que no se tenga en cuenta esta property en la base de datos, ya que es una propiedad logica de la aplicacion
        public int Id { get => IdCliente; set => IdCliente = value; }

    }

    [MetadataType(typeof(PedidoMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class Pedido : IIdentificableEntity, IAuditableEntity
    {
        [NotMapped] // Para que no se tenga en cuenta esta property en la base de datos, ya que es una propiedad logica de la aplicacion
        public int Id { get => IdPedido; set => IdPedido = value; }
    }

    [MetadataType(typeof(PedidoArticuloMetadata))] // Con este decorador "MetadataType" asociamos las clases "Metadata" que realizarán validaciones sobre el modelo
    public partial class PedidoArticulo
    {
    }

}
