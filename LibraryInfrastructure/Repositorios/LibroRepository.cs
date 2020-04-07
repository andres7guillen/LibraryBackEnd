using LibraryData.Context;
using LibraryDomain.Entidades.DTO;
using LibraryDomain.Entities;
using LibraryDomain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Repositorios
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibraryContext _context;
        public LibroRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Libro> Actualizar(Libro Libro)
        {
            try
            {
                _context.Libros.Update(Libro);
                await _context.SaveChangesAsync();
                return Libro;
            }
            catch (Exception e)
            {
                throw e; 
            }
        }

        public async Task<Libro> Crear(Libro Libro)
        {
            try
            {
                Libro.Id = Guid.NewGuid();
                await _context.Libros.AddAsync(Libro);
                await _context.SaveChangesAsync();
                return Libro;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Eliminar(Guid Id)
        {
            try
            {
                var libro = await _context.Libros.FirstOrDefaultAsync(a => a.Id == Id);
                _context.Libros.Remove(libro);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<List<Libro>> FiltrarLibros(filtroDTO filtro)
        {
            return await _context.Libros.Include(l => l.Categoria).Include(l => l.Autor)
                .Where(l => l.AutorId == filtro.autorId ||
                       l.CategoriaId == filtro.categoriaId ||
                       l.Nombre.Contains(filtro.nombreLibro))                
                .ToListAsync();
        }

        public async Task<Libro> ObtenerLibroPorGuid(Guid Id)
        {
            try
            {
                return await _context.Libros
                    .Include(l => l.Categoria)
                    .Include(l => l.Autor)
                    .FirstOrDefaultAsync(l => l.Id == Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Libro> ObtenerLibroPorNombre(string nombre)
        {
            try
            {
                return await _context.Libros
                                .Include(l => l.Autor)
                                .FirstOrDefaultAsync(l => l.Nombre == nombre);
            }
            catch (Exception e)
            {
                throw;
            }            
        }

        public async Task<List<Libro>> ObtenerLibrosPorAutor(Guid AutorId)
        {
            try
            {
                return await _context.Libros
                    .Include(a => a.Autor)
                    .Where(l => l.AutorId == AutorId).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Libro>> ObtenerLibrosPorCategoria(Guid CategoriaId)
        {
            try
            {
                return await _context.Libros.Include(l => l.Autor)
                    .Where(l => l.CategoriaId == CategoriaId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Libro>> ObtenerTodos()
        {
            try
            {
                 return await _context.Libros.Include(l => l.Categoria).Include(l => l.Autor).ToListAsync();                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
