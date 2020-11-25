using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/transportes")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        private readonly ModelContext context;

        public TransporteController(ModelContext context)
        {
            this.context = context;
        }
        // GET: api/<TransporteController>
        [HttpGet]
        public IEnumerable<AspNetUsers> Get()
        {
            return context.AspNetUsers.Where(x => x.TipoUsuario == "Transportista").ToList();
        }

        //// GET api/<TransporteController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<TransporteController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TransporteController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TransporteController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
