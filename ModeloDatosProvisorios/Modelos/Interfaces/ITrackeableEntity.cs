﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Modelos.Interfaces
{
    /* Interface con properties necesarias para realizar el seguimiento del objeto */
    public interface ITrackeableEntity
    {

        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string BorradoPor { get; set; }
    }
}