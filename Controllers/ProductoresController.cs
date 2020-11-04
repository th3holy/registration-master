using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/productores")]
    [ApiController]
    public class ProductoresController : ControllerBase
    {
        private readonly ModelContext context;

        public ProductoresController( ModelContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductoresController>
        [HttpGet]
        public IEnumerable<AspNetUsers> Get()
        {
            return context.AspNetUsers.Where(u =>u.TipoUsuario == "Productor").ToList();
        }

        //// GET api/<ProductoresController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductoresController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductoresController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductoresController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
