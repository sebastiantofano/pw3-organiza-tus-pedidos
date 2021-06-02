using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAL.Modelos
{
    public partial class Usuario
    {
        public Usuario()
        {
            ArticuloBorradoPorNavigations = new HashSet<Articulo>();
            ArticuloCreadoPorNavigations = new HashSet<Articulo>();
            ArticuloModificadoPorNavigations = new HashSet<Articulo>();
            ClienteBorradoPorNavigations = new HashSet<Cliente>();
            ClienteCreadoPorNavigations = new HashSet<Cliente>();
            ClienteModificadoPorNavigations = new HashSet<Cliente>();
            InverseModificadoPorNavigation = new HashSet<Usuario>();
            PedidoBorradoPorNavigations = new HashSet<Pedido>();
            PedidoCreadoPorNavigations = new HashSet<Pedido>();
            PedidoModificadoPorNavigations = new HashSet<Pedido>();
        }

        // TODO : SACAR DE ACA ESTA PROPERTY ROLES, PROVISORIO
        [NotMapped]
        public string Roles {
            get {
                return EsAdmin ? "Administrador" : "Moderador";
            }
            set { }
        }

        public int IdUsuario { get; set; }
        public bool EsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaUltLogin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public int? ModificadoPor { get; set; }
        public int? CreadoPor { get; set; }
        public int? BorradoPor { get; set; }

        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Articulo> ArticuloBorradoPorNavigations { get; set; }
        public virtual ICollection<Articulo> ArticuloCreadoPorNavigations { get; set; }
        public virtual ICollection<Articulo> ArticuloModificadoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteBorradoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteCreadoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteModificadoPorNavigations { get; set; }
        public virtual ICollection<Usuario> InverseModificadoPorNavigation { get; set; }
        public virtual ICollection<Pedido> PedidoBorradoPorNavigations { get; set; }
        public virtual ICollection<Pedido> PedidoCreadoPorNavigations { get; set; }
        public virtual ICollection<Pedido> PedidoModificadoPorNavigations { get; set; }
    }
}
