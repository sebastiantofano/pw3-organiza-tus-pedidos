using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public long CUIT { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string ModificadoPor { get; set; }
        public string CreadorPor { get; set; }
        public string BorradoPor { get; set; }
    }
}
