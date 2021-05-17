using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
        public int NumeroPedido { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string CreadorPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }
    }
}
