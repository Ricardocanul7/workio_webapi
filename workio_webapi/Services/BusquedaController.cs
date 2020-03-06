using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workio_webapi.Models;

namespace workio_webapi.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public BusquedaController(dbworkioContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Busca trabajos por categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>lista de trabajos</returns>
        [HttpGet("trabajo/[action]/{descripcion}")]
        public ActionResult<IEnumerable<PublicacionTrabajo>> Categoria(string descripcion)
        {
            var trabajos = _context.PublicacionTrabajo.Where(p => p.Categoria.Descripcion.Contains(descripcion));

            if(trabajos.Any())
            {
                return Ok(trabajos.ToList());
            }

            return NotFound();
        }

        /// <summary>
        /// Busca trabajos por medio del estado usando el id
        /// </summary>
        /// <param name="estado_id"></param>
        /// <returns></returns>
        [HttpGet("trabajo/[action]/{id}")]
        public ActionResult Estado(int id)
        {
            var trabajos = _context.PublicacionTrabajo.Where(s => s.Estado.Id == id);

            if (trabajos.Any())
            {
                return Ok(trabajos.ToList());
            }

            return NotFound();
        }
    }
}