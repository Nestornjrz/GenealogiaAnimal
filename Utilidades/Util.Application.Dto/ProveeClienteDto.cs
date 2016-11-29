using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util.Application.Dto
{
    public class ProveeClienteDto
    {
        public int ProveeClienteId { get; set; }
        public string Nombre { get; set; }
        public bool ProveedorSn { get; set; }
        public bool ClienteSn { get; set; }

    }
}
