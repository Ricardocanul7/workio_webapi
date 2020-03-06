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
    public class UbicacionsController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public UbicacionsController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Ubicacions
        [HttpGet]
        public IEnumerable<Ubicacion> GetUbicacion()
        {
            return _context.Ubicacion;
        }

        // GET: api/Ubicacions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUbicacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/Ubicacions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion([FromRoute] int id, [FromBody] Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicacions
        [HttpPost]
        public async Task<IActionResult> PostUbicacion([FromBody] Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ubicacion.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacion", new { id = ubicacion.Id }, ubicacion);
        }

        // DELETE: api/Ubicacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ubicacion = await _context.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return Ok(ubicacion);
        }

        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.Id == id);
        }
    }
}