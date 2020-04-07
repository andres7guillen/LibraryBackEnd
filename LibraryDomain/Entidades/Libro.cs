using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDomain.Entities
{
    public class Libro
    {
        public Guid Id { get; set; }

        [StringLength(80)]
        public string Nombre { get; set; }
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [StringLength(100)]
        public string ISBN { get; set; }
    }
}
