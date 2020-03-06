using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Modulos
    {
        public Modulos()
        {
            Elementos = new HashSet<Elementos>();
            PerfilModulo = new HashSet<PerfilModulo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Elementos> Elementos { get; set; }
        public ICollection<PerfilModulo> PerfilModulo { get; set; }
    }
}
