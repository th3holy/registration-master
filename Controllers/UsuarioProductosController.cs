using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/usuarioProducto")]
    [ApiController]
    public class UsuarioProductosController : ControllerBase
    {
        private readonly ModelContext context;

        public UsuarioProductosController(ModelContext context)
        {
            this.context = context;
        }
        // GET: api/<UsuarioProductosController>
        [HttpGet("{id}")]
        public IEnumerable<Product> Get(string id )
        {
            return context.Product.Where(u =>u.IdUser == id).ToList();
        }

        //// GET api/<UsuarioProductosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsuarioProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
