using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workio_webapi.Models;

namespace workio_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public MetodoPagosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/MetodoPagos
        [HttpGet]
        public IEnumerable<MetodoPago> GetMetodoPago()
        {
            return _context.MetodoPago;
        }

        // GET: api/MetodoPagos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMetodoPago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metodoPago = await _context.MetodoPago.FindAsync(id);

            if (metodoPago == null)
            {
                return NotFound();
            }

            return Ok(metodoPago);
        }

        // PUT: api/MetodoPagos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoPago([FromRoute] int id, [FromBody] MetodoPago metodoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metodoPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(metodoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoPagoExists(id))
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

        // POST: api/MetodoPagos
        [HttpPost]
        public async Task<IActionResult> PostMetodoPago([FromBody] MetodoPago metodoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MetodoPago.Add(metodoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetodoPago", new { id = metodoPago.Id }, metodoPago);
        }

        // DELETE: api/MetodoPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoPago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            _context.MetodoPago.Remove(metodoPago);
            await _context.SaveChangesAsync();

            return Ok(metodoPago);
        }

        private bool MetodoPagoExists(int id)
        {
            return _context.MetodoPago.Any(e => e.Id == id);
        }
    }
}