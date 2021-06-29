﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class UsuarioLogueadoDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public UsuarioLogueadoDTO(int idUsuario, string nombre, string apellido, DateTime? fechaNacimiento)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
