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
    public class PublicacionTrabajosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public PublicacionTrabajosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/PublicacionTrabajos
        [HttpGet]
        public IEnumerable<PublicacionTrabajo> GetPublicacionTrabajo()
        {
            return _context.PublicacionTrabajo;
        }

        // GET: api/PublicacionTrabajos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacionTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publicacionTrabajo = await _context.PublicacionTrabajo.FindAsync(id);

            if (publicacionTrabajo == null)
            {
                return NotFound();
            }

            return Ok(publicacionTrabajo);
        }

        // PUT: api/PublicacionTrabajos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacionTrabajo([FromRoute] int id, [FromBody] PublicacionTrabajo publicacionTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publicacionTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicacionTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionTrabajoExists(id))
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

        // POST: api/PublicacionTrabajos
        [HttpPost]
        public async Task<IActionResult> PostPublicacionTrabajo([FromBody] PublicacionTrabajo publicacionTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PublicacionTrabajo.Add(publicacionTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacionTrabajo", new { id = publicacionTrabajo.Id }, publicacionTrabajo);
        }

        // DELETE: api/PublicacionTrabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacionTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publicacionTrabajo = await _context.PublicacionTrabajo.FindAsync(id);
            if (publicacionTrabajo == null)
            {
                return NotFound();
            }

            _context.PublicacionTrabajo.Remove(publicacionTrabajo);
            await _context.SaveChangesAsync();

            return Ok(publicacionTrabajo);
        }

        private bool PublicacionTrabajoExists(int id)
        {
            return _context.PublicacionTrabajo.Any(e => e.Id == id);
        }
    }
}