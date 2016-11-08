using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class RegistroZootecnicos
    {
        public long VacunoId { get; set; }
        public int GeneracionId { get; set; }
        public int GradoSangreId { get; set; }
        public int NroRebano { get; set; }
        public string Hbp { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime MomentoCarga { get; set; }

        public virtual Generaciones Generacion { get; set; }
        public virtual GradoSangres GradoSangre { get; set; }
        public virtual VacunoCaracteristicas Vacuno { get; set; }
    }
}
