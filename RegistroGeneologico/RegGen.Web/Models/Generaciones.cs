using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Generaciones
    {
        public Generaciones()
        {
            RegistroZootecnicos = new HashSet<RegistroZootecnicos>();
        }

        public int GeneracionId { get; set; }
        public int RazaId { get; set; }
        public string NombreGeneracion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RegistroZootecnicos> RegistroZootecnicos { get; set; }
        public virtual Razas Raza { get; set; }
    }
}
