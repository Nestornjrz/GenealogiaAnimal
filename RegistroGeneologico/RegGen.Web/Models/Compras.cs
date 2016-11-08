using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class Compras
    {
        public long VacunoId { get; set; }
        public int OrigenId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioCompra { get; set; }
        public double PesoAlComprarKg { get; set; }
        public string Observacion { get; set; }

        public virtual Origenes Origen { get; set; }
        public virtual VacunoCaracteristicas Vacuno { get; set; }
    }
}
