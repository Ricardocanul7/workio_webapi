using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class EstadoUsuario
    {
        public EstadoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Estatus { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
