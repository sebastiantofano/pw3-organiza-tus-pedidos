using System;

namespace ModeloDatosProvisorios.Modelos
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadorPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }

    }
}
