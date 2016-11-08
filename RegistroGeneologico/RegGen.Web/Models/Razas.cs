using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Razas
    {
        public Razas()
        {
            Generaciones = new HashSet<Generaciones>();
            GradoSangres = new HashSet<GradoSangres>();
            VacunoCaracteristicas = new HashSet<VacunoCaracteristicas>();
        }

        public int RazaId { get; set; }
        public string NombreRaza { get; set; }

        public virtual ICollection<Generaciones> Generaciones { get; set; }
        public virtual ICollection<GradoSangres> GradoSangres { get; set; }
        public virtual ICollection<VacunoCaracteristicas> VacunoCaracteristicas { get; set; }
    }
}
