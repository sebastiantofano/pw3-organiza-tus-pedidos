﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public interface IDatos<TEntity>
    {
        List<TEntity> ListadoObjetos { get; }
    }
}
