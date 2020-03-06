using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            ElementosPermisos = new HashSet<ElementosPermisos>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<ElementosPermisos> ElementosPermisos { get; set; }
    }
}
