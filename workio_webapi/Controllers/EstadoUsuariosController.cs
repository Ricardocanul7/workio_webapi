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
    public class EstadoUsuariosController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public EstadoUsuariosController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/EstadoUsuarios
        [HttpGet]
        public IEnumerable<EstadoUsuario> GetEstadoUsuario()
        {
            return _context.EstadoUsuario;
        }

        // GET: api/EstadoUsuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoUsuario = await _context.EstadoUsuario.FindAsync(id);

            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return Ok(estadoUsuario);
        }

        // PUT: api/EstadoUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoUsuario([FromRoute] int id, [FromBody] EstadoUsuario estadoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoUsuarioExists(id))
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

        // POST: api/EstadoUsuarios
        [HttpPost]
        public async Task<IActionResult> PostEstadoUsuario([FromBody] EstadoUsuario estadoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EstadoUsuario.Add(estadoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoUsuario", new { id = estadoUsuario.Id }, estadoUsuario);
        }

        // DELETE: api/EstadoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoUsuario = await _context.EstadoUsuario.FindAsync(id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            _context.EstadoUsuario.Remove(estadoUsuario);
            await _context.SaveChangesAsync();

            return Ok(estadoUsuario);
        }

        private bool EstadoUsuarioExists(int id)
        {
            return _context.EstadoUsuario.Any(e => e.Id == id);
        }
    }
}