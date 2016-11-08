using System;
using System.Collections.Generic;

namespace RegGen.Web.Models
{
    public partial class VacunoHembras
    {
        public long VacunoId { get; set; }

        public virtual Vacunos Vacuno { get; set; }
    }
}
