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
    public class DocumentosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public DocumentosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Documentos
        [HttpGet]
        public IEnumerable<Documento> GetDocumento()
        {
            return _context.Documento;
        }

        // GET: api/Documentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documento = await _context.Documento.FindAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            return Ok(documento);
        }

        // PUT: api/Documentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento([FromRoute] int id, [FromBody] Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documento.IdDocumento)
            {
                return BadRequest();
            }

            _context.Entry(documento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
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

        // POST: api/Documentos
        [HttpPost]
        public async Task<IActionResult> PostDocumento([FromBody] Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Documento.Add(documento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumento", new { id = documento.IdDocumento }, documento);
        }

        // DELETE: api/Documentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documento = await _context.Documento.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            _context.Documento.Remove(documento);
            await _context.SaveChangesAsync();

            return Ok(documento);
        }

        private bool DocumentoExists(int id)
        {
            return _context.Documento.Any(e => e.IdDocumento == id);
        }
    }
}