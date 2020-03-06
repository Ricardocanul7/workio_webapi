using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Documento> Documento { get; set; }
    }
}
