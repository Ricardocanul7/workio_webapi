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
    public class ElementosPermisosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public ElementosPermisosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/ElementosPermisos
        [HttpGet]
        public IEnumerable<ElementosPermisos> GetElementosPermisos()
        {
            return _context.ElementosPermisos;
        }

        // GET: api/ElementosPermisos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElementosPermisos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementosPermisos = await _context.ElementosPermisos.FindAsync(id);

            if (elementosPermisos == null)
            {
                return NotFound();
            }

            return Ok(elementosPermisos);
        }

        // PUT: api/ElementosPermisos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementosPermisos([FromRoute] int id, [FromBody] ElementosPermisos elementosPermisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementosPermisos.Id)
            {
                return BadRequest();
            }

            _context.Entry(elementosPermisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementosPermisosExists(id))
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

        // POST: api/ElementosPermisos
        [HttpPost]
        public async Task<IActionResult> PostElementosPermisos([FromBody] ElementosPermisos elementosPermisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ElementosPermisos.Add(elementosPermisos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElementosPermisos", new { id = elementosPermisos.Id }, elementosPermisos);
        }

        // DELETE: api/ElementosPermisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementosPermisos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementosPermisos = await _context.ElementosPermisos.FindAsync(id);
            if (elementosPermisos == null)
            {
                return NotFound();
            }

            _context.ElementosPermisos.Remove(elementosPermisos);
            await _context.SaveChangesAsync();

            return Ok(elementosPermisos);
        }

        private bool ElementosPermisosExists(int id)
        {
            return _context.ElementosPermisos.Any(e => e.Id == id);
        }
    }
}