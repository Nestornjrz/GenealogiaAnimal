using System;
using System.Collections.Generic;

namespace Util.Impresion.Web.ReverseEngenieer
{
    public partial class Guias
    {
        public Guias()
        {
            GuiasDet = new HashSet<GuiasDet>();
        }

        public long GuiaId { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<GuiasDet> GuiasDet { get; set; }
    }
}
