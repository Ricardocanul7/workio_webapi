using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class LogLogin
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
