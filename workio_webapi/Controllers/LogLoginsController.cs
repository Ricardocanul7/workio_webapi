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
    public class LogLoginsController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public LogLoginsController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/LogLogins
        [HttpGet]
        public IEnumerable<LogLogin> GetLogLogin()
        {
            return _context.LogLogin;
        }

        // GET: api/LogLogins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logLogin = await _context.LogLogin.FindAsync(id);

            if (logLogin == null)
            {
                return NotFound();
            }

            return Ok(logLogin);
        }

        // PUT: api/LogLogins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogLogin([FromRoute] int id, [FromBody] LogLogin logLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logLogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(logLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogLoginExists(id))
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

        // POST: api/LogLogins
        [HttpPost]
        public async Task<IActionResult> PostLogLogin([FromBody] LogLogin logLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LogLogin.Add(logLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogLogin", new { id = logLogin.Id }, logLogin);
        }

        // DELETE: api/LogLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logLogin = await _context.LogLogin.FindAsync(id);
            if (logLogin == null)
            {
                return NotFound();
            }

            _context.LogLogin.Remove(logLogin);
            await _context.SaveChangesAsync();

            return Ok(logLogin);
        }

        private bool LogLoginExists(int id)
        {
            return _context.LogLogin.Any(e => e.Id == id);
        }
    }
}