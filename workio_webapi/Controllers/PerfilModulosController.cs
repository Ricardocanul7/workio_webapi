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
    public class PerfilModulosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public PerfilModulosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/PerfilModulos
        [HttpGet]
        public IEnumerable<PerfilModulo> GetPerfilModulo()
        {
            return _context.PerfilModulo;
        }

        // GET: api/PerfilModulos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfilModulo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfilModulo = await _context.PerfilModulo.FindAsync(id);

            if (perfilModulo == null)
            {
                return NotFound();
            }

            return Ok(perfilModulo);
        }

        // PUT: api/PerfilModulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfilModulo([FromRoute] int id, [FromBody] PerfilModulo perfilModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfilModulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfilModulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilModuloExists(id))
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

        // POST: api/PerfilModulos
        [HttpPost]
        public async Task<IActionResult> PostPerfilModulo([FromBody] PerfilModulo perfilModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PerfilModulo.Add(perfilModulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfilModulo", new { id = perfilModulo.Id }, perfilModulo);
        }

        // DELETE: api/PerfilModulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfilModulo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfilModulo = await _context.PerfilModulo.FindAsync(id);
            if (perfilModulo == null)
            {
                return NotFound();
            }

            _context.PerfilModulo.Remove(perfilModulo);
            await _context.SaveChangesAsync();

            return Ok(perfilModulo);
        }

        private bool PerfilModuloExists(int id)
        {
            return _context.PerfilModulo.Any(e => e.Id == id);
        }
    }
}