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
    public class PublicacionesServiceController : ControllerBase
    {
        // Comienza desde 0 como un arreglo
        [HttpGet("[Action]")]
        public IEnumerable<PublicacionTrabajo> GetFirstPublicaciones(int pageNumber, int range)
        {
            int rowInit = pageNumber * range;

            using(var db = new dbworkioContext())
            {
                var results = db.PublicacionTrabajo.OrderBy(p => p.FechaPublicacion).Skip(rowInit).Take(range);
                return results.ToList();
            }
        }

        [HttpGet("[Action]")]
        public IEnumerable<PublicacionTrabajo> GetLastPublicaciones(int pageNumber, int range)
        {
            int rowInit = pageNumber * range;

            using (var db = new dbworkioContext())
            {
                var results = db.PublicacionTrabajo.OrderByDescending(p => p.FechaPublicacion).Skip(rowInit).Take(range);
                return results.ToList();
            }
        }

        [HttpGet("[Action]")]
        public IEnumerable<PublicacionTrabajo> GetLastPublicacionesByCategoria(string categoria, int pageNumber, int range)
        {
            int rowInit = pageNumber * range;

            using (var db = new dbworkioContext())
            {
                var results = db.PublicacionTrabajo.Where(p => p.Categoria.Descripcion.Contains(categoria)).OrderByDescending(p => p.FechaPublicacion).Skip(rowInit).Take(range);
                return results.ToList();
            }
        }
    }
}