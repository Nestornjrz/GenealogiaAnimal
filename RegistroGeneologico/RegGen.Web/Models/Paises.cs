using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Departamentos = new HashSet<Departamentos>();
        }

        public int PaisId { get; set; }
        public string NombrePais { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Departamentos> Departamentos { get; set; }
    }
}
