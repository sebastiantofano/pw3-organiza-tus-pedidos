using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModeloDatosProvisorios.Modelos
{
    public class Pedido
    {
        [Required(ErrorMessage = "Id Requerido")]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
        public int NumeroPedido { get; set; }
        public string Comentarios { get; set; }
        public DateTime? FechaCreacion { get; private set; } = DateTime.Today;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadorPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }
    }
}
