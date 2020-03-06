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
    public class AplicarTrabajosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public AplicarTrabajosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/AplicarTrabajos
        [HttpGet]
        public IEnumerable<AplicarTrabajo> GetAplicarTrabajo()
        {
            return _context.AplicarTrabajo;
        }

        // GET: api/AplicarTrabajos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAplicarTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aplicarTrabajo = await _context.AplicarTrabajo.FindAsync(id);

            if (aplicarTrabajo == null)
            {
                return NotFound();
            }

            return Ok(aplicarTrabajo);
        }

        // PUT: api/AplicarTrabajos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicarTrabajo([FromRoute] int id, [FromBody] AplicarTrabajo aplicarTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aplicarTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicarTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicarTrabajoExists(id))
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

        // POST: api/AplicarTrabajos
        [HttpPost]
        public async Task<IActionResult> PostAplicarTrabajo([FromBody] AplicarTrabajo aplicarTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AplicarTrabajo.Add(aplicarTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicarTrabajo", new { id = aplicarTrabajo.Id }, aplicarTrabajo);
        }

        // DELETE: api/AplicarTrabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicarTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aplicarTrabajo = await _context.AplicarTrabajo.FindAsync(id);
            if (aplicarTrabajo == null)
            {
                return NotFound();
            }

            _context.AplicarTrabajo.Remove(aplicarTrabajo);
            await _context.SaveChangesAsync();

            return Ok(aplicarTrabajo);
        }

        private bool AplicarTrabajoExists(int id)
        {
            return _context.AplicarTrabajo.Any(e => e.Id == id);
        }
    }
}