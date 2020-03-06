using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class EstadoPublicacionTrabajo
    {
        public EstadoPublicacionTrabajo()
        {
            PublicacionTrabajo = new HashSet<PublicacionTrabajo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<PublicacionTrabajo> PublicacionTrabajo { get; set; }
    }
}
