using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain.Repositorios
{
    public interface ICategoriaRepository
    {
        Task<Categoria> Crear(Categoria Categoria);
        Task<Categoria> ObtenerPorGuid(Guid CategoriaId);
        Task<List<Categoria>> ObtenerTodos();
        Task<Categoria> Actualizar(Categoria Categoria);
        Task<bool> Eliminar(Guid CategoriaId);
    }
}
