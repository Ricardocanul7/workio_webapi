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
    public class ElementosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public ElementosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Elementos
        [HttpGet]
        public IEnumerable<Elementos> GetElementos()
        {
            return _context.Elementos;
        }

        // GET: api/Elementos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElementos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementos = await _context.Elementos.FindAsync(id);

            if (elementos == null)
            {
                return NotFound();
            }

            return Ok(elementos);
        }

        // PUT: api/Elementos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementos([FromRoute] int id, [FromBody] Elementos elementos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementos.Id)
            {
                return BadRequest();
            }

            _context.Entry(elementos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementosExists(id))
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

        // POST: api/Elementos
        [HttpPost]
        public async Task<IActionResult> PostElementos([FromBody] Elementos elementos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Elementos.Add(elementos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElementos", new { id = elementos.Id }, elementos);
        }

        // DELETE: api/Elementos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementos = await _context.Elementos.FindAsync(id);
            if (elementos == null)
            {
                return NotFound();
            }

            _context.Elementos.Remove(elementos);
            await _context.SaveChangesAsync();

            return Ok(elementos);
        }

        private bool ElementosExists(int id)
        {
            return _context.Elementos.Any(e => e.Id == id);
        }
    }
}