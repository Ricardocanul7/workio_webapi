using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Mensaje
    {
        public int Id { get; set; }
        public string Mensaje1 { get; set; }
        public DateTime FechaEnviado { get; set; }
        public DateTime FechaLeido { get; set; }
        public int EmisorId { get; set; }
        public int ReceptorId { get; set; }

        public Persona Emisor { get; set; }
        public Persona Receptor { get; set; }
    }
}
