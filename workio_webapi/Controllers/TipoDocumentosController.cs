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
    public class TipoDocumentosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public TipoDocumentosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/TipoDocumentos
        [HttpGet]
        public IEnumerable<TipoDocumento> GetTipoDocumento()
        {
            return _context.TipoDocumento;
        }

        // GET: api/TipoDocumentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(tipoDocumento);
        }

        // PUT: api/TipoDocumentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumento([FromRoute] int id, [FromBody] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDocumento.IdTipoDocumento)
            {
                return BadRequest();
            }

            _context.Entry(tipoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoExists(id))
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

        // POST: api/TipoDocumentos
        [HttpPost]
        public async Task<IActionResult> PostTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoDocumento.Add(tipoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDocumento", new { id = tipoDocumento.IdTipoDocumento }, tipoDocumento);
        }

        // DELETE: api/TipoDocumentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            _context.TipoDocumento.Remove(tipoDocumento);
            await _context.SaveChangesAsync();

            return Ok(tipoDocumento);
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.TipoDocumento.Any(e => e.IdTipoDocumento == id);
        }
    }
}