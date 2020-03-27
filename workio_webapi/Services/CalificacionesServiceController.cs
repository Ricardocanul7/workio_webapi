using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workio_webapi.Models;

namespace workio_webapi.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesServiceController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public CalificacionesServiceController(dbworkioContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Calificaciones>> CalificacionesByIdTrabajador(int id)
        {
            var calific = _context.Calificaciones.Where(c => c.TrabajadorId == id).ToList();

            if (calific.Any())
            {
                return calific;
            }

            return NotFound();
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Calificaciones>> CalificacionesByIdEmpleador(int id)
        {
            var calific = _context.Calificaciones.Where(c => c.EmpleadorId == id).ToList();

            if (calific.Any())
            {
                return calific;
            }

            return NotFound();
        }
    }
}