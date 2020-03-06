using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Pagos = new HashSet<Pagos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Pagos> Pagos { get; set; }
    }
}
