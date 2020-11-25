using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/contrato")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly ModelContext context;

        public ContratoController(ModelContext context )
        {
            this.context = context;
        }
        // GET: api/<ContratoController>
        [HttpGet]
        public IEnumerable<Contrato> Get()
        {
            return context.Contrato.ToList();
        }

        // GET api/<ContratoController>/5
        [HttpGet("{id}")]
        public Contrato Get(string id)
        {
            var contrato = context.Contrato.FirstOrDefault(c => c.IdUser == id);
            return contrato;
        }

        // POST api/<ContratoController>
        [HttpPost]
        public ActionResult Post([FromBody] Contrato contrato)
        {
            try
            {
                context.Contrato.Add(contrato);
                context.SaveChanges();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
