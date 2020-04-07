using LibraryAPI.Models;
using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Converts
{
    public static class AutorConvert
    {
        public static Autor toEntity(AutorModel input)
        {
            Autor output = new Autor();
            output.Apellidos = input.Apellidos != null ? output.Apellidos = input.Apellidos : output.Apellidos = "-o-";
            output.FechaNacimiento = input.FechaNacimiento != null ? output.FechaNacimiento = input.FechaNacimiento : output.FechaNacimiento = new DateTime(0, 0, 0);
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.NewGuid();            
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            
            return output;
        }

        public static List<Autor> toListEntity(List<AutorModel> input)
        {
            return input.Select(l => toEntity(l)).ToList();
        }

        public static AutorModel toModel(Autor input)
        {
            AutorModel output = new AutorModel();
            output.Apellidos = input.Apellidos != null ? output.Apellidos = input.Apellidos : output.Apellidos = "-o-";
            output.FechaNacimiento = input.FechaNacimiento != null ? output.FechaNacimiento = input.FechaNacimiento : output.FechaNacimiento = new DateTime(0, 0, 0);
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = Guid.Empty.ToString();
            //output.Libros = input.Libros != null ? output.Libros = LibroConvert.toListModel(input.Libros) : output.Libros = new List<LibroModel>();
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            return output;
        }

        public static List<AutorModel> toListModel(List<Autor> input)
        {
            return input.Select(a => toModel(a)).ToList();
        }
    }
}
