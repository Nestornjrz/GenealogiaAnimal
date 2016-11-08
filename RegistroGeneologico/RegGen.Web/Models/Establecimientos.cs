using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Establecimientos
    {
        public Establecimientos()
        {
            VacunoCaracteristicas = new HashSet<VacunoCaracteristicas>();
        }

        public int EstablecimientoId { get; set; }
        public string NombreEstablecimiento { get; set; }
        public int CiudadId { get; set; }
        public int PropietarioId { get; set; }

        public virtual ICollection<VacunoCaracteristicas> VacunoCaracteristicas { get; set; }
        public virtual Ciudades Ciudad { get; set; }
        public virtual Propietarios Propietario { get; set; }
    }
}
