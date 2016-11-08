using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Propietarios
    {
        public Propietarios()
        {
            Establecimientos = new HashSet<Establecimientos>();
        }

        public int PropietarioId { get; set; }
        public string NombrePropietario { get; set; }
        public string Siglas { get; set; }
        public string RucCi { get; set; }

        public virtual ICollection<Establecimientos> Establecimientos { get; set; }
    }
}
