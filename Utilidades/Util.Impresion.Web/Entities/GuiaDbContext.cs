using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util.Impresion.Web.Entities
{
    public class GuiaDbContext:DbContext
    {
        public GuiaDbContext(DbContextOptions opciones):base(opciones) {

        }
    }
}
