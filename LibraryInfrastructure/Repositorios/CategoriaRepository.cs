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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly LibraryContext _context;
        public CategoriaRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Categoria> Actualizar(Categoria Categoria)
        {
            try
            {
                _context.Update(Categoria);
                await _context.SaveChangesAsync();
                return Categoria;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Categoria> Crear(Categoria Categoria)
        {
            try
            {
                Categoria.Id = Guid.NewGuid();
                await _context.Categorias.AddAsync(Categoria);
                await _context.SaveChangesAsync();
                return Categoria;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Eliminar(Guid CategoriaId)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == CategoriaId);
                _context.Categorias.Remove(categoria);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Categoria> ObtenerPorGuid(Guid CategoriaId)
        {
            try
            {
                return await _context.Categorias
                                .FirstOrDefaultAsync(c => c.Id == CategoriaId);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<List<Categoria>> ObtenerTodos()
        {
            try
            {
                return await _context.Categorias
                                .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
