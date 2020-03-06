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
    public class TiposReportesController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public TiposReportesController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/TiposReportes
        [HttpGet]
        public IEnumerable<TiposReportes> GetTiposReportes()
        {
            return _context.TiposReportes;
        }

        // GET: api/TiposReportes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTiposReportes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tiposReportes = await _context.TiposReportes.FindAsync(id);

            if (tiposReportes == null)
            {
                return NotFound();
            }

            return Ok(tiposReportes);
        }

        // PUT: api/TiposReportes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposReportes([FromRoute] int id, [FromBody] TiposReportes tiposReportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposReportes.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiposReportes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposReportesExists(id))
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

        // POST: api/TiposReportes
        [HttpPost]
        public async Task<IActionResult> PostTiposReportes([FromBody] TiposReportes tiposReportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TiposReportes.Add(tiposReportes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposReportes", new { id = tiposReportes.Id }, tiposReportes);
        }

        // DELETE: api/TiposReportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposReportes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tiposReportes = await _context.TiposReportes.FindAsync(id);
            if (tiposReportes == null)
            {
                return NotFound();
            }

            _context.TiposReportes.Remove(tiposReportes);
            await _context.SaveChangesAsync();

            return Ok(tiposReportes);
        }

        private bool TiposReportesExists(int id)
        {
            return _context.TiposReportes.Any(e => e.Id == id);
        }
    }
}