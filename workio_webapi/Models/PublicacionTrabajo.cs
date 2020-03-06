using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class PublicacionTrabajo
    {
        public PublicacionTrabajo()
        {
            AplicarTrabajo = new HashSet<AplicarTrabajo>();
            Pagos = new HashSet<Pagos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public int PersonaOrigenId { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime? FechaCompletado { get; set; }
        public int? UbicacionId { get; set; }
        public int EstadoId { get; set; }

        public CategoriaTrabajo Categoria { get; set; }
        public EstadoPublicacionTrabajo Estado { get; set; }
        public Persona PersonaOrigen { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public ICollection<AplicarTrabajo> AplicarTrabajo { get; set; }
        public ICollection<Pagos> Pagos { get; set; }
    }
}
