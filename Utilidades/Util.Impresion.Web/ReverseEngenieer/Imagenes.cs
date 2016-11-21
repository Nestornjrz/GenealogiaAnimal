﻿using System;
using System.Collections.Generic;

namespace Util.Impresion.Web.ReverseEngenieer
{
    public partial class Imagenes
    {
        public Imagenes()
        {
            GuiasDet = new HashSet<GuiasDet>();
        }

        public int ImagenId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<GuiasDet> GuiasDet { get; set; }
    }
}
