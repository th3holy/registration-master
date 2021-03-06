﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registration.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registration.Controllers
{
    [Route("api/productoentrega")]
    [ApiController]
    public class productoEntregaController : ControllerBase
    {
        private readonly ModelContext context;

        public productoEntregaController(ModelContext context)
        {
            this.context = context;
        }
       
        // GET: api/<ProductoCompradoController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Product.Where(u => u.Status == "Entrega").ToList();
        }

        // GET api/<ProductoCompradoController>/5
        [HttpGet("{id}")]
        public IEnumerable<Product> Get(string id)
        {
            return context.Product.Where(u => u.IdUser == id).Where(u => u.Status == "Entrega").ToList();
        }



        // PUT api/<productoEntregaController>/5
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

            producto.Status = "Entrega";


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
