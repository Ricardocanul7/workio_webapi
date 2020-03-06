using System;
using System.Collections.Generic;

namespace workio_webapi.Models
{
    public partial class LogBusquedaCategorias
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CategoriaId { get; set; }

        public CategoriaTrabajo Categoria { get; set; }
    }
}
