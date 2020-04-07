using LibraryDomain.Entities;
using LibraryDomain.Repositorios;
using LibraryDomain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Categoria> Actualizar(Categoria Categoria) => await _repository.Actualizar(Categoria);

        public async Task<Categoria> Crear(Categoria Categoria) => await _repository.Crear(Categoria);

        public async Task<bool> Eliminar(Guid CategoriaId) => await _repository.Eliminar(CategoriaId);

        public async Task<Categoria> ObtenerPorGuid(Guid CategoriaId) => await _repository.ObtenerPorGuid(CategoriaId);

        public async Task<List<Categoria>> ObtenerTodos() => await _repository.ObtenerTodos();
    }
}
