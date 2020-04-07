using LibraryDomain.Entities;
using LibraryDomain.Repositorios;
using LibraryDomain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Servicios
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;
        public AutorService(IAutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Autor> Actualizar(Autor Autor) => await _repository.Actualizar(Autor);

        public async Task<Autor> Crear(Autor Autor) => await _repository.Crear(Autor);

        public async Task<bool> Eliminar(Guid AutorId) => await _repository.Eliminar(AutorId);

        public async Task<Autor> ObtenerPorGuid(Guid AutorId) => await _repository.ObtenerPorGuid(AutorId);

        public async Task<List<Autor>> ObtenerTodos() => await _repository.ObtenerTodos();
    }
}
