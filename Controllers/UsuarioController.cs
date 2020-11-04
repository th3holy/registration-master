using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ModelContext context;

        public UsuarioController(ModelContext context)
        {
            this.context = context;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<AspNetUsers> Get()
        {
            return context.AspNetUsers.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public AspNetUsers Get(string id)
        {
            var usuario = context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            return usuario;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
