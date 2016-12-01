using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Application.Dto;
using Util.Impresion.Web.V2.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Util.Impresion.Web.V2.Controllers {
    [Route("api/[controller]")]
    public class ProveeClientesController : Controller {

        // GET: api/values
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ProveeClienteDto> GetProveedores() {
            using (var context = new GuiaDbContext()) {
                return context.ProveeClientes
                    .Where(w => w.ProveedorSn == true)
                    .Select(s => new ProveeClienteDto() {
                        ProveeClienteId = s.ProveeClienteId,
                        Nombre = s.Nombre
                    }).ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
