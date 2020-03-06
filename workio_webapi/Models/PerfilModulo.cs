using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class PerfilModulo
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int ModulosId { get; set; }

        public Modulos Modulos { get; set; }
        public Perfil Perfil { get; set; }
    }
}
