using LibraryDomain.Entidades.DTO;
using LibraryDomain.Entities;
using LibraryDomain.Repositorios;
using LibraryDomain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Servicios
{
    public class LibroService : ILibroService
    {
        private ILibroRepository _repository;
        public LibroService(ILibroRepository repository)
        {
            _repository = repository;
        }
        public async Task<Libro> Actualizar(Libro Libro) => await _repository.Actualizar(Libro);

        public async Task<Libro> Crear(Libro Libro) => await _repository.Crear(Libro);

        public async Task<bool> Eliminar(Guid LibroId) => await _repository.Eliminar(LibroId);

        public async Task<List<Libro>> FiltrarLibros(filtroDTO filtro) => await _repository.FiltrarLibros(filtro);

        public async Task<Libro> ObtenerLibroPorGuid(Guid Id) => await _repository.ObtenerLibroPorGuid(Id);

        public async Task<Libro> ObtenerLibroPorNombre(string nombre) => await _repository.ObtenerLibroPorNombre(nombre);

        public async Task<List<Libro>> ObtenerLibrosPorAutor(Guid AutorId) => await _repository.ObtenerLibrosPorAutor(AutorId);

        public async Task<List<Libro>> ObtenerLibrosPorCategoria(Guid CategoriaId) => await _repository.ObtenerLibrosPorCategoria(CategoriaId);

        public async Task<List<Libro>> ObtenerTodos() => await _repository.ObtenerTodos();
    }
}
