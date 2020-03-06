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
    public class CalificacionesController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public CalificacionesController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Calificaciones
        [HttpGet]
        public IEnumerable<Calificaciones> GetCalificaciones()
        {
            return _context.Calificaciones;
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificaciones([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calificaciones = await _context.Calificaciones.FindAsync(id);

            if (calificaciones == null)
            {
                return NotFound();
            }

            return Ok(calificaciones);
        }

        // PUT: api/Calificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificaciones([FromRoute] int id, [FromBody] Calificaciones calificaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(calificaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionesExists(id))
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

        // POST: api/Calificaciones
        [HttpPost]
        public async Task<IActionResult> PostCalificaciones([FromBody] Calificaciones calificaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Calificaciones.Add(calificaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificaciones", new { id = calificaciones.Id }, calificaciones);
        }

        // DELETE: api/Calificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificaciones([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calificaciones = await _context.Calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificaciones);
            await _context.SaveChangesAsync();

            return Ok(calificaciones);
        }

        private bool CalificacionesExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}