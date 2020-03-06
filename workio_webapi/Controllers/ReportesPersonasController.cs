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
    public class ReportesPersonasController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public ReportesPersonasController(dbworkioContext context)
        {
            _context = context;
        }

        // GET: api/ReportesPersonas
        [HttpGet]
        public IEnumerable<ReportesPersona> GetReportesPersona()
        {
            return _context.ReportesPersona;
        }

        // GET: api/ReportesPersonas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportesPersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reportesPersona = await _context.ReportesPersona.FindAsync(id);

            if (reportesPersona == null)
            {
                return NotFound();
            }

            return Ok(reportesPersona);
        }

        // PUT: api/ReportesPersonas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportesPersona([FromRoute] int id, [FromBody] ReportesPersona reportesPersona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportesPersona.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportesPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportesPersonaExists(id))
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

        // POST: api/ReportesPersonas
        [HttpPost]
        public async Task<IActionResult> PostReportesPersona([FromBody] ReportesPersona reportesPersona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReportesPersona.Add(reportesPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportesPersona", new { id = reportesPersona.Id }, reportesPersona);
        }

        // DELETE: api/ReportesPersonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportesPersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reportesPersona = await _context.ReportesPersona.FindAsync(id);
            if (reportesPersona == null)
            {
                return NotFound();
            }

            _context.ReportesPersona.Remove(reportesPersona);
            await _context.SaveChangesAsync();

            return Ok(reportesPersona);
        }

        private bool ReportesPersonaExists(int id)
        {
            return _context.ReportesPersona.Any(e => e.Id == id);
        }
    }
}