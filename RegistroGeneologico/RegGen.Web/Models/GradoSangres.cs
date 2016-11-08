using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class GradoSangres
    {
        public GradoSangres()
        {
            RegistroZootecnicos = new HashSet<RegistroZootecnicos>();
        }

        public int GradoSangreId { get; set; }
        public int RazaId { get; set; }
        public string NombreGradoSangre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RegistroZootecnicos> RegistroZootecnicos { get; set; }
        public virtual Razas Raza { get; set; }
    }
}
