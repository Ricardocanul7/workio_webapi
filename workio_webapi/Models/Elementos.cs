using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Elementos
    {
        public Elementos()
        {
            ElementosPermisos = new HashSet<ElementosPermisos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ModulosId { get; set; }

        public Modulos Modulos { get; set; }
        public ICollection<ElementosPermisos> ElementosPermisos { get; set; }
    }
}
