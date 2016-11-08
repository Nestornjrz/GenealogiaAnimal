using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Pelajes
    {
        public Pelajes()
        {
            VacunoCaracteristicas = new HashSet<VacunoCaracteristicas>();
        }

        public int PelajeId { get; set; }
        public string ColorPelaje { get; set; }

        public virtual ICollection<VacunoCaracteristicas> VacunoCaracteristicas { get; set; }
    }
}
