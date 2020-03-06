using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Calificaciones
    {
        public int Id { get; set; }
        public int Estrellas { get; set; }
        public string Comentarios { get; set; }
        public int TrabajadorId { get; set; }
        public int EmpleadorId { get; set; }

        public Persona Empleador { get; set; }
        public Persona Trabajador { get; set; }
    }
}
