using LibraryAPI.Models;
using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Converts
{
    public static class CategoriaConvert
    {
        public static Categoria toEntity(CategoriaModel input)
        {
            Categoria output = new Categoria();
            output.Descripcion = input.Descripcion != null ? output.Descripcion = input.Descripcion : output.Descripcion = "-o-";
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.Empty;
            output.Libros = input.Libros != null ? output.Libros = LibroConvert.toListEntity(input.Libros) : output.Libros = new List<Libro>();
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            return output;
        }

        public static List<Categoria> toListEntity(List<CategoriaModel> input)
        {
            return input.Select(c => toEntity(c)).ToList();
        }

        public static CategoriaModel toModel(Categoria input)
        {
            CategoriaModel output = new CategoriaModel();
            output.Descripcion = input.Descripcion != null ? output.Descripcion = input.Descripcion : output.Descripcion = "-o-";
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = Guid.Empty.ToString();
            //output.Libros = input.Libros != null ? output.Libros = LibroConvert.toListModel(input.Libros) : output.Libros = new List<LibroModel>();
            output.Nombre = input.Nombre != null ? output.Nombre = input.Nombre : output.Nombre = "-o-";
            return output;
        }

        public static List<CategoriaModel> toListModel(List<Categoria> input)
        {
            return input.Select(c => toModel(c)).ToList();
        }


    }
}
