using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public string Texto { get; set; }
        public string FotoUrl { get; set; }
        public DateTime? FechaAceptacion { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public bool Estatus { get; set; }
        public int PersonaId { get; set; }
        public int TipoDocumentoId { get; set; }

        public Persona Persona { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}
