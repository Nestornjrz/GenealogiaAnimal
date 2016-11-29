using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Util.Impresion.Web.Controllers {
    [Route("api/[controller]")]
    public class UploadFileController : Controller {
        private IHostingEnvironment _environment;
        public UploadFileController(IHostingEnvironment environment) {
            _environment = environment;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post(IFormFile file) {
            var mensaje = "";
            try {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                if (file.Length > 0) {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create)) {
                        file.CopyTo(fileStream);
                    }
                }       
                mensaje = "Subio el archivo " + file.FileName;
            } catch (Exception ex) {
                mensaje = string.Format("Error: {0}", ex.Message);

            }

            return mensaje;
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
