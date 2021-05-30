using ModeloDatosProvisorios.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModeloDatosProvisorios.Modelos
{
    public class Pedido : BaseEntity, ITrackeableEntity
    {
        public int IdPedido {
            get {
                return base.Id;
            }
            set {
                base.Id = value;
            }
        }

        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
        public int NumeroPedido { get; set; }
        public string Comentarios { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.Today;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }
    }
}
