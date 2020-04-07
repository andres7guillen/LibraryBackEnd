using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class LibroModel
    {
        public string Id { get; set; }

        [StringLength(80)]
        public string Nombre { get; set; }
        public string AutorId { get; set; }
        public AutorModel Autor { get; set; }

        public string CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }

        [StringLength(100)]
        public string ISBN { get; set; }
    }
}
