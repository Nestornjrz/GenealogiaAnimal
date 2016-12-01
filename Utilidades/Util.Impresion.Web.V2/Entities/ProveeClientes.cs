using System;
using System.Collections.Generic;

namespace Util.Impresion.Web.V2.Entities {
    public partial class ProveeClientes
    {
        public ProveeClientes()
        {
            GuiasDet = new HashSet<GuiasDet>();
            Imagenes = new HashSet<Imagenes>();
        }

        public int ProveeClienteId { get; set; }
        public string Nombre { get; set; }
        public bool ProveedorSn { get; set; }
        public bool ClienteSn { get; set; }

        public virtual ICollection<GuiasDet> GuiasDet { get; set; }
        public virtual ICollection<Imagenes> Imagenes { get; set; }
    }
}
