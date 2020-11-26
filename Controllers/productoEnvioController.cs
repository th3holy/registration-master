using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/productoenvio")]
    [ApiController]
    public class productoEnvioController : ControllerBase
    {
        private readonly ModelContext context;

        public productoEnvioController(ModelContext context)
        {
            this.context = context;
        }
        

        // PUT api/<productoEnvioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Status([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var producto = await context.Product.FirstOrDefaultAsync(p => p.CodProducto == id);
            if (producto == null)
            {
                return NotFound();

            }
          
                producto.Status = "Envio";
            
            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return Ok();
        }


    }
}
