using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Vacunos
    {
        public long VacunoId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public int RegistroParticular { get; set; }
        public int RpTemporal { get; set; }
        public DateTime MomentoCarga { get; set; }

        public virtual VacunoCaracteristicas VacunoCaracteristicas { get; set; }
        public virtual VacunoHembras VacunoHembras { get; set; }
        public virtual VacunoMachos VacunoMachos { get; set; }
    }
}
