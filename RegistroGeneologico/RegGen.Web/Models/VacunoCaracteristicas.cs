using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class VacunoCaracteristicas
    {
        public long VacunoId { get; set; }
        public int EstablecimientoId { get; set; }
        public int PelajeId { get; set; }
        public int RazaId { get; set; }

        public virtual Compras Compras { get; set; }
        public virtual RegistroZootecnicos RegistroZootecnicos { get; set; }
        public virtual Establecimientos Establecimiento { get; set; }
        public virtual Pelajes Pelaje { get; set; }
        public virtual Razas Raza { get; set; }
        public virtual Vacunos Vacuno { get; set; }
    }
}
