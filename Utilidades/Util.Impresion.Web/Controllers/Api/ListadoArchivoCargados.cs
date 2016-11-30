using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Util.Impresion.Web.Controllers {
    [Route("api/[controller]")]
    public class ListadoArchivoCargadosController : Controller {
        private IHostingEnvironment _environment;

        public ListadoArchivoCargadosController(IHostingEnvironment environment) {
            _environment = environment;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            var archivos = new List<string>();
            foreach (string file in Directory.EnumerateFiles(
                  Path.Combine(_environment.WebRootPath,"uploads"), "*",
                  SearchOption.AllDirectories
                )) {
                var separados = file.Split('\\');                
                archivos.Add("uploads/" + separados[separados.Length - 1]);
            }
           
            return archivos;
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
