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
    public class ElementoPermitidosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public ElementoPermitidosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/ElementoPermitidos
        [HttpGet]
        public IEnumerable<ElementoPermitido> GetElementoPermitido()
        {
            return _context.ElementoPermitido;
        }

        // GET: api/ElementoPermitidos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElementoPermitido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementoPermitido = await _context.ElementoPermitido.FindAsync(id);

            if (elementoPermitido == null)
            {
                return NotFound();
            }

            return Ok(elementoPermitido);
        }

        // PUT: api/ElementoPermitidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementoPermitido([FromRoute] int id, [FromBody] ElementoPermitido elementoPermitido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementoPermitido.Id)
            {
                return BadRequest();
            }

            _context.Entry(elementoPermitido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoPermitidoExists(id))
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

        // POST: api/ElementoPermitidos
        [HttpPost]
        public async Task<IActionResult> PostElementoPermitido([FromBody] ElementoPermitido elementoPermitido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ElementoPermitido.Add(elementoPermitido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElementoPermitido", new { id = elementoPermitido.Id }, elementoPermitido);
        }

        // DELETE: api/ElementoPermitidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementoPermitido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementoPermitido = await _context.ElementoPermitido.FindAsync(id);
            if (elementoPermitido == null)
            {
                return NotFound();
            }

            _context.ElementoPermitido.Remove(elementoPermitido);
            await _context.SaveChangesAsync();

            return Ok(elementoPermitido);
        }

        private bool ElementoPermitidoExists(int id)
        {
            return _context.ElementoPermitido.Any(e => e.Id == id);
        }
    }
}