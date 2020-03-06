using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class ReportesPersona
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoReporteId { get; set; }
        public string Descripcion { get; set; }
        public int PersonaId { get; set; }

        public Persona Persona { get; set; }
        public TiposReportes TipoReporte { get; set; }
    }
}
