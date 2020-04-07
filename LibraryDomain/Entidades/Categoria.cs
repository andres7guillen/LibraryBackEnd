using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDomain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }        
        public List<Libro> Libros { get; set; }
    }
}
