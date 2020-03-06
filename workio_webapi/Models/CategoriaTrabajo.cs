using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class CategoriaTrabajo
    {
        public CategoriaTrabajo()
        {
            LogBusquedaCategorias = new HashSet<LogBusquedaCategorias>();
            PublicacionTrabajo = new HashSet<PublicacionTrabajo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<LogBusquedaCategorias> LogBusquedaCategorias { get; set; }
        public ICollection<PublicacionTrabajo> PublicacionTrabajo { get; set; }
    }
}
