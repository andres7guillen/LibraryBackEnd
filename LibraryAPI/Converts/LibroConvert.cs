using LibraryAPI.Models;
using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Converts
{
    public static class LibroConvert
    {
        public static Libro toEntity(LibroModel input)
        {
            Libro output = new Libro();            
            output.AutorId = input.AutorId != null ? output.AutorId = Guid.Parse(input.AutorId) : output.AutorId = Guid.Empty;           
            output.CategoriaId = input.CategoriaId != null ? output.CategoriaId = Guid.Parse(input.CategoriaId) : output.CategoriaId = Guid.Empty;
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.Empty;
            output.ISBN = input.ISBN != null ? output.ISBN = input.ISBN : output.ISBN = "-o-";
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            return output;
        }

        public static List<Libro> toListEntity(List<LibroModel> input)
        {
            return input.Select(l => toEntity(l)).ToList();
        }

        public static LibroModel toModel(Libro input)
        {
            LibroModel output = new LibroModel();
            if(input.Autor != null)
            {
                output.Autor = new AutorModel();
                output.Autor.Apellidos = input.Autor.Apellidos;
                output.Autor.FechaNacimiento = input.Autor.FechaNacimiento;
                output.Autor.Id = input.Autor.Id.ToString();
                output.Autor.Nombre = input.Autor.Nombre;
            }
            
            output.AutorId = input.AutorId != null ? output.AutorId = input.AutorId.ToString() : output.AutorId = Guid.Empty.ToString();
            if (input.Categoria != null)
            {
                output.Categoria = new CategoriaModel();
                output.Categoria.Descripcion = input.Categoria.Descripcion;
                output.Categoria.Id = input.Categoria.Id.ToString();
                output.Categoria.Nombre = input.Categoria.Nombre;                
            } 
            
            output.CategoriaId = input.CategoriaId != null ? output.CategoriaId = input.CategoriaId.ToString() : output.CategoriaId = Guid.Empty.ToString();
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = Guid.Empty.ToString();
            output.ISBN = input.ISBN != null ? output.ISBN = input.ISBN : output.ISBN = "-o-";
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            return output;
        }

        public static List<LibroModel> toListModel(List<Libro> input)
        {
            return input.Select(l => toModel(l)).ToList();
        }
    }
}
