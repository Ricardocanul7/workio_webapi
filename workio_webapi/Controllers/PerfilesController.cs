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
    public class PerfilesController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public PerfilesController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/Perfiles
        [HttpGet]
        public IEnumerable<Perfil> GetPerfil()
        {
            return _context.Perfil;
        }

        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil([FromRoute] int id, [FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfiles
        [HttpPost]
        public async Task<IActionResult> PostPerfil([FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perfil.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();

            return Ok(perfil);
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.Id == id);
        }
    }
}