using System;
using System.Collections.Generic;

namespace Util.Impresion.Web.Entities {
    public partial class Imagenes
    {
        public Imagenes()
        {
            GuiasDet = new HashSet<GuiasDet>();
        }

        public int ImagenId { get; set; }
        public int ProveedorId { get; set; }
        public bool VigenteSn { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<GuiasDet> GuiasDet { get; set; }
        public virtual ProveeClientes Proveedor { get; set; }
    }
}
