using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Persona
    {
        public Persona()
        {
            AplicarTrabajo = new HashSet<AplicarTrabajo>();
            CalificacionesEmpleador = new HashSet<Calificaciones>();
            CalificacionesTrabajador = new HashSet<Calificaciones>();
            Documento = new HashSet<Documento>();
            MensajeEmisor = new HashSet<Mensaje>();
            MensajeReceptor = new HashSet<Mensaje>();
            Pagos = new HashSet<Pagos>();
            PublicacionTrabajo = new HashSet<PublicacionTrabajo>();
            ReportesPersona = new HashSet<ReportesPersona>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FotoUrl { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        public ICollection<AplicarTrabajo> AplicarTrabajo { get; set; }
        public ICollection<Calificaciones> CalificacionesEmpleador { get; set; }
        public ICollection<Calificaciones> CalificacionesTrabajador { get; set; }
        public ICollection<Documento> Documento { get; set; }
        public ICollection<Mensaje> MensajeEmisor { get; set; }
        public ICollection<Mensaje> MensajeReceptor { get; set; }
        public ICollection<Pagos> Pagos { get; set; }
        public ICollection<PublicacionTrabajo> PublicacionTrabajo { get; set; }
        public ICollection<ReportesPersona> ReportesPersona { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
