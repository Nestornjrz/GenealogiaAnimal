using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Establecimientos = new HashSet<Establecimientos>();
        }

        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public int DepartamentoId { get; set; }

        public virtual ICollection<Establecimientos> Establecimientos { get; set; }
        public virtual Departamentos Departamento { get; set; }
    }
}
