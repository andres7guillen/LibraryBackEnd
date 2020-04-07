using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain.Repositorios
{
    public interface IAutorRepository
    {
        Task<Autor> Crear(Autor Autor);
        Task<Autor> ObtenerPorGuid(Guid AutorId);
        Task<List<Autor>> ObtenerTodos();
        Task<Autor> Actualizar(Autor Autor);
        Task<bool> Eliminar(Guid AutorId);
    }
}
