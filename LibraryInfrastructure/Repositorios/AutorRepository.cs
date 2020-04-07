using LibraryData.Context;
using LibraryDomain.Entities;
using LibraryDomain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Repositorios
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibraryContext _context;
        public AutorRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Autor> Actualizar(Autor Autor)
        {
            try
            {
                _context.Autores.Update(Autor);
                await _context.SaveChangesAsync();
                return Autor;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<Autor> Crear(Autor Autor)
        {
            try
            {
                Autor.Id = Guid.NewGuid();
                await _context.Autores.AddAsync(Autor);
                await _context.SaveChangesAsync();
                return Autor;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<bool> Eliminar(Guid AutorId)
        {
            try
            {
                var Autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == AutorId);
                _context.Autores.Remove(Autor);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<Autor> ObtenerPorGuid(Guid AutorId)
        {
            try
            {
                return await _context.Autores.FirstOrDefaultAsync(a => a.Id == AutorId);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            try
            {
                return await _context.Autores
                             .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
