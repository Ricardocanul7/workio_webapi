using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class TiposReportes
    {
        public TiposReportes()
        {
            ReportesPersona = new HashSet<ReportesPersona>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<ReportesPersona> ReportesPersona { get; set; }
    }
}
