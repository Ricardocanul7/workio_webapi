using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class ElementoPermitido
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int ElementosPermisosId { get; set; }

        public ElementosPermisos ElementosPermisos { get; set; }
        public Perfil Perfil { get; set; }
    }
}
