using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            ElementoPermitido = new HashSet<ElementoPermitido>();
            PerfilModulo = new HashSet<PerfilModulo>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string TipoUsuario { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ElementoPermitido> ElementoPermitido { get; set; }
        public ICollection<PerfilModulo> PerfilModulo { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
