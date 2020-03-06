using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            PublicacionTrabajo = new HashSet<PublicacionTrabajo>();
        }

        public int Id { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Direccion { get; set; }
        public string Referencias { get; set; }

        public ICollection<PublicacionTrabajo> PublicacionTrabajo { get; set; }
    }
}
