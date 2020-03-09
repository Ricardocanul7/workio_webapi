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
        [HttpGet]
        public IEnumerable<PublicacionTrabajo> GetPublicacionesOffset(int pageNumber, int range)
        {
            int rowInit = pageNumber * range;

            using(var db = new dbworkioContext())
            {
                var results = db.PublicacionTrabajo.Skip(rowInit).Take(range);
                return results.ToList();
            }
        }
    }
}