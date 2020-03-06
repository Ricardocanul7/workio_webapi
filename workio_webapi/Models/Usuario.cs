using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            LogLogin = new HashSet<LogLogin>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstatusId { get; set; }
        public int PersonaId { get; set; }
        public int PerfilId { get; set; }

        public EstadoUsuario Estatus { get; set; }
        public Perfil Perfil { get; set; }
        public Persona Persona { get; set; }
        public ICollection<LogLogin> LogLogin { get; set; }
    }
}
