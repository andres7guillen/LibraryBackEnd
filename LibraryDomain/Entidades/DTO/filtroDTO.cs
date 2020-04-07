using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDomain.Entidades.DTO
{
    public class filtroDTO
    {
        public string nombreLibro { get; set; }
        public Guid? categoriaId { get; set; }
        public Guid? autorId { get; set; }
    }
}
