using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class AplicarTrabajo
    {
        public int Id { get; set; }
        public int PublicacionId { get; set; }
        public int PersonaId { get; set; }
        public decimal Presupuesto { get; set; }
        public DateTime Fecha { get; set; }

        public Persona Persona { get; set; }
        public PublicacionTrabajo Publicacion { get; set; }
    }
}
