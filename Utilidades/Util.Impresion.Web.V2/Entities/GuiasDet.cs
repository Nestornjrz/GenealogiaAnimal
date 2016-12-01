using System;
using System.Collections.Generic;

namespace Util.Impresion.Web.V2.Entities {
    public partial class GuiasDet
    {
        public long GuiaDetId { get; set; }
        public long GuiaId { get; set; }
        public int? ImagenId { get; set; }
        public int? ClienteId { get; set; }

        public virtual ProveeClientes Cliente { get; set; }
        public virtual Guias Guia { get; set; }
        public virtual Imagenes Imagen { get; set; }
    }
}
