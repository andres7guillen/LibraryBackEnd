using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDomain.Entities
{
    public class Autor
    {
        public Guid Id { get; set; }

        [StringLength(80)]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
