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
    public class PagosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public PagosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Pagos
        [HttpGet]
        public IEnumerable<Pagos> GetPagos()
        {
            return _context.Pagos;
        }

        // GET: api/Pagos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagos = await _context.Pagos.FindAsync(id);

            if (pagos == null)
            {
                return NotFound();
            }

            return Ok(pagos);
        }

        // PUT: api/Pagos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagos([FromRoute] int id, [FromBody] Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagosExists(id))
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

        // POST: api/Pagos
        [HttpPost]
        public async Task<IActionResult> PostPagos([FromBody] Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pagos.Add(pagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagos", new { id = pagos.Id }, pagos);
        }

        // DELETE: api/Pagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return Ok(pagos);
        }

        private bool PagosExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}