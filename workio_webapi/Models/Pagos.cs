using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class Pagos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int MetodoPagoId { get; set; }
        public int PublicacionId { get; set; }
        public int TrabajadorId { get; set; }
        public decimal Cantidad { get; set; }

        public MetodoPago MetodoPago { get; set; }
        public PublicacionTrabajo Publicacion { get; set; }
        public Persona Trabajador { get; set; }
    }
}
