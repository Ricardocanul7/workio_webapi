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
    public class EstadoPublicacionTrabajosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public EstadoPublicacionTrabajosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPublicacionTrabajos
        [HttpGet]
        public IEnumerable<EstadoPublicacionTrabajo> GetEstadoPublicacionTrabajo()
        {
            return _context.EstadoPublicacionTrabajo;
        }

        // GET: api/EstadoPublicacionTrabajos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoPublicacionTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoPublicacionTrabajo = await _context.EstadoPublicacionTrabajo.FindAsync(id);

            if (estadoPublicacionTrabajo == null)
            {
                return NotFound();
            }

            return Ok(estadoPublicacionTrabajo);
        }

        // PUT: api/EstadoPublicacionTrabajos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPublicacionTrabajo([FromRoute] int id, [FromBody] EstadoPublicacionTrabajo estadoPublicacionTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoPublicacionTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoPublicacionTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPublicacionTrabajoExists(id))
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

        // POST: api/EstadoPublicacionTrabajos
        [HttpPost]
        public async Task<IActionResult> PostEstadoPublicacionTrabajo([FromBody] EstadoPublicacionTrabajo estadoPublicacionTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EstadoPublicacionTrabajo.Add(estadoPublicacionTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPublicacionTrabajo", new { id = estadoPublicacionTrabajo.Id }, estadoPublicacionTrabajo);
        }

        // DELETE: api/EstadoPublicacionTrabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPublicacionTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoPublicacionTrabajo = await _context.EstadoPublicacionTrabajo.FindAsync(id);
            if (estadoPublicacionTrabajo == null)
            {
                return NotFound();
            }

            _context.EstadoPublicacionTrabajo.Remove(estadoPublicacionTrabajo);
            await _context.SaveChangesAsync();

            return Ok(estadoPublicacionTrabajo);
        }

        private bool EstadoPublicacionTrabajoExists(int id)
        {
            return _context.EstadoPublicacionTrabajo.Any(e => e.Id == id);
        }
    }
}