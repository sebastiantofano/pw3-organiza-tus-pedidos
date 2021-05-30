﻿using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public class ArticulosDatos
    {
        private static Articulo art1 = new Articulo {
            IdArticulo = 1,
            Codigo = "COD_01",
            Descripcion = "Descripción del Articulo 1",
            CreadoPor = "Sebastian Tofano",
            FechaModificacion = new DateTime(2021, 11, 02),
            ModificadoPor = "Pepito Perez"
        };
        private static Articulo art2 = new Articulo { IdArticulo = 2, Codigo = "COD_02", Descripcion = "Descripción del Articulo 2", CreadoPor = "Sebastian Tofano", FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art3 = new Articulo { IdArticulo = 3, Codigo = "COD_03", Descripcion = "Descripción del Articulo 3", CreadoPor = "Sebastian Tofano", };
        private static Articulo art4 = new Articulo { IdArticulo = 4, Codigo = "COD_04", Descripcion = "Descripción del Articulo 4", CreadoPor = "Sebastian Tofano", FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art5 = new Articulo { IdArticulo = 5, Codigo = "COD_05", Descripcion = "Descripción del Articulo 5", CreadoPor = "Sebastian Tofano", };
        private static Articulo art6 = new Articulo { IdArticulo = 6, Codigo = "COD_06", Descripcion = "Descripción del Articulo 6", CreadoPor = "Sebastian Tofano", };
        private static Articulo art7 = new Articulo { IdArticulo = 7, Codigo = "COD_07", Descripcion = "Descripción del Articulo 7", CreadoPor = "Sebastian Tofano", FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art8 = new Articulo { IdArticulo = 8, Codigo = "COD_08", Descripcion = "Descripción del Articulo 8", CreadoPor = "Sebastian Tofano", };
        private static Articulo art9 = new Articulo { IdArticulo = 9, Codigo = "COD_09", Descripcion = "Descripción del Articulo 9", CreadoPor = "Sebastian Tofano", };


        public static List<Articulo> ListaArticulos = new() { art1, art2, art3, art4, art5, art6, art7, art8, art9 };


    }
}
