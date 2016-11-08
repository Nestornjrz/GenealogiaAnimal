using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Origenes
    {
        public Origenes()
        {
            Compras = new HashSet<Compras>();
        }

        public int OrigenId { get; set; }
        public string NombreOrigen { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
    }
}
