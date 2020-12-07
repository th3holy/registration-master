using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registration.models;

namespace registration.Controllers
{
    [Route("api/contratotransporte")]
    [ApiController]
    public class TransportesController : ControllerBase
    {
        private readonly ModelContext _context;

        public TransportesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Transportes
        [HttpGet]
        public IEnumerable<Transporte> GetTransporte()
        {
            return _context.Transporte;
        }

        // GET: api/Transportes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransporte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transporte = await _context.Transporte.FindAsync(id);

            if (transporte == null)
            {
                return NotFound();
            }

            return Ok(transporte);
        }

        // PUT: api/Transportes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransporte([FromRoute] int id, [FromBody] Transporte transporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transporte.IdTransporte)
            {
                return BadRequest();
            }

            _context.Entry(transporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transportes
        [HttpPost]
        public async Task<IActionResult> PostTransporte([FromBody] Transporte transporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Transporte.Add(transporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransporte", new { id = transporte.IdTransporte }, transporte);
        }

        // DELETE: api/Transportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransporte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }

            _context.Transporte.Remove(transporte);
            await _context.SaveChangesAsync();

            return Ok(transporte);
        }

        private bool TransporteExists(int id)
        {
            return _context.Transporte.Any(e => e.IdTransporte == id);
        }
    }
}