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
    public class LogBusquedaCategoriasController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public LogBusquedaCategoriasController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/LogBusquedaCategorias
        [HttpGet]
        public IEnumerable<LogBusquedaCategorias> GetLogBusquedaCategorias()
        {
            return _context.LogBusquedaCategorias;
        }

        // GET: api/LogBusquedaCategorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogBusquedaCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logBusquedaCategorias = await _context.LogBusquedaCategorias.FindAsync(id);

            if (logBusquedaCategorias == null)
            {
                return NotFound();
            }

            return Ok(logBusquedaCategorias);
        }

        // PUT: api/LogBusquedaCategorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogBusquedaCategorias([FromRoute] int id, [FromBody] LogBusquedaCategorias logBusquedaCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logBusquedaCategorias.Id)
            {
                return BadRequest();
            }

            _context.Entry(logBusquedaCategorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogBusquedaCategoriasExists(id))
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

        // POST: api/LogBusquedaCategorias
        [HttpPost]
        public async Task<IActionResult> PostLogBusquedaCategorias([FromBody] LogBusquedaCategorias logBusquedaCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LogBusquedaCategorias.Add(logBusquedaCategorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogBusquedaCategorias", new { id = logBusquedaCategorias.Id }, logBusquedaCategorias);
        }

        // DELETE: api/LogBusquedaCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogBusquedaCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logBusquedaCategorias = await _context.LogBusquedaCategorias.FindAsync(id);
            if (logBusquedaCategorias == null)
            {
                return NotFound();
            }

            _context.LogBusquedaCategorias.Remove(logBusquedaCategorias);
            await _context.SaveChangesAsync();

            return Ok(logBusquedaCategorias);
        }

        private bool LogBusquedaCategoriasExists(int id)
        {
            return _context.LogBusquedaCategorias.Any(e => e.Id == id);
        }
    }
}