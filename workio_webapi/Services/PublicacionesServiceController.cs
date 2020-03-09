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
        public IEnumerable<PublicacionTrabajo> GetPublicacionesOffset(int offset)
        {
            int range = 10;

            using(var db = new dbworkioContext())
            {
                var results = db.PublicacionTrabajo.Skip(offset).Take(range);
                return results.ToList();
            }
        }
    }
}