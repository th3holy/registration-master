using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ModelContext context;

        public VentaController(ModelContext context)
        {
            this.context = context;
        }
        // GET: api/<VentaController>
        [HttpGet]
        public IEnumerable<Ventas> Get()
        {
            return context.Ventas.ToList();
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public Ventas Get(int id)
        {
            var Venta = context.Ventas.FirstOrDefault(v => v.IdProducto == id);
            return Venta;
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Ventas ventas)
        {
            try
            {
                context.Ventas.Add(ventas);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //// PUT api/<VentaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<VentaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
