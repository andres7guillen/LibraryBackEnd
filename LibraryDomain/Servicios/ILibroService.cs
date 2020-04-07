using LibraryDomain.Entidades.DTO;
using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain.Services
{
    public interface ILibroService
    {
        Task<Libro> Crear(Libro Libro);
        Task<Libro> ObtenerLibroPorNombre(string nombre);
        Task<List<Libro>> ObtenerLibrosPorCategoria(Guid CategoriaId);
        Task<List<Libro>> ObtenerLibrosPorAutor(Guid AutorId);
        Task<Libro> ObtenerLibroPorGuid(Guid Id);
        Task<List<Libro>> ObtenerTodos();
        Task<Libro> Actualizar(Libro Libro);
        Task<bool> Eliminar(Guid LibroId);
        Task<List<Libro>> FiltrarLibros(filtroDTO filtro);
    }
}
