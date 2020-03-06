using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class ElementosPermisos
    {
        public ElementosPermisos()
        {
            ElementoPermitido = new HashSet<ElementoPermitido>();
        }

        public int Id { get; set; }
        public int ElementosId { get; set; }
        public int PermisosId { get; set; }

        public Elementos Elementos { get; set; }
        public Permisos Permisos { get; set; }
        public ICollection<ElementoPermitido> ElementoPermitido { get; set; }
    }
}
