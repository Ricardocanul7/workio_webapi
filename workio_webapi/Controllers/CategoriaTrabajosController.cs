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
    public class CategoriaTrabajosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public CategoriaTrabajosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaTrabajos
        [HttpGet]
        public IEnumerable<CategoriaTrabajo> GetCategoriaTrabajo()
        {
            return _context.CategoriaTrabajo;
        }

        // GET: api/CategoriaTrabajos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaTrabajo = await _context.CategoriaTrabajo.FindAsync(id);

            if (categoriaTrabajo == null)
            {
                return NotFound();
            }

            return Ok(categoriaTrabajo);
        }

        // PUT: api/CategoriaTrabajos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaTrabajo([FromRoute] int id, [FromBody] CategoriaTrabajo categoriaTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaTrabajoExists(id))
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

        // POST: api/CategoriaTrabajos
        [HttpPost]
        public async Task<IActionResult> PostCategoriaTrabajo([FromBody] CategoriaTrabajo categoriaTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoriaTrabajo.Add(categoriaTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaTrabajo", new { id = categoriaTrabajo.Id }, categoriaTrabajo);
        }

        // DELETE: api/CategoriaTrabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaTrabajo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaTrabajo = await _context.CategoriaTrabajo.FindAsync(id);
            if (categoriaTrabajo == null)
            {
                return NotFound();
            }

            _context.CategoriaTrabajo.Remove(categoriaTrabajo);
            await _context.SaveChangesAsync();

            return Ok(categoriaTrabajo);
        }

        private bool CategoriaTrabajoExists(int id)
        {
            return _context.CategoriaTrabajo.Any(e => e.Id == id);
        }
    }
}