using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
        public int PaisId { get; set; }

        public virtual ICollection<Ciudades> Ciudades { get; set; }
        public virtual Paises Pais { get; set; }
    }
}
