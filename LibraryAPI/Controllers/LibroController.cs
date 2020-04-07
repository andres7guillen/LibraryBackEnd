using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Converts;
using LibraryAPI.Models;
using LibraryDomain.Entidades.DTO;
using LibraryDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibroController(ILibroService service)
        {
            _service = service;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]LibroModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Crear(LibroConvert.toEntity(model));
                    if (result != null)
                    {
                        return Ok(LibroConvert.toModel(result));
                    }
                    else
                    {
                        return BadRequest("Error creando la Libro!!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("ObtenerPorNombre")]
        public async Task<IActionResult> ObtenerPorNombre(string Nombre)
        {
            try
            {
                var result = await _service.ObtenerLibroPorNombre(Nombre);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(LibroConvert.toModel(result));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("ObtenerPorAutor")]
        public async Task<IActionResult> ObtenerPorAutor(string Id)
        {
            try
            {
                Guid id = Guid.Parse(Id);                 
                var result = await _service.ObtenerLibrosPorAutor(id);
                if (result.Count >= 1)
                {
                    return Ok(LibroConvert.toListModel(result));
                }
                else
                {
                    return BadRequest("No hay libros por ese Autor");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("ObtenerPorGuid")]
        public async Task<IActionResult> ObtenerPorGuid(string Id)
        {
            try
            {
                Guid id = Guid.Parse(Id);
                var result = await _service.ObtenerLibroPorGuid(id);
                if (result != null)
                {
                    return Ok(LibroConvert.toModel(result));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("ObtenerPorCategoria")]
        public async Task<IActionResult> ObtenerPorCategoria(string Id)
        {
            try
            {
                Guid id = Guid.Parse(Id);
                var result = await _service.ObtenerLibrosPorCategoria(id);
                if (result.Count >= 1)
                {
                    return Ok(LibroConvert.toListModel(result));
                }
                else
                {
                    return BadRequest("Error consultando Libros");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var result = await _service.ObtenerTodos();
                if (result.Count >= 1)
                {
                    return Ok(LibroConvert.toListModel(result));
                }
                else
                {
                    return BadRequest("No hay libros registrados!!!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]LibroModel Libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Actualizar(LibroConvert.toEntity(Libro));
                    return Ok(LibroConvert.toModel(result));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(string Id)
        {
            try
            {
                Guid id = Guid.Parse(Id);
                var result = await _service.Eliminar(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpPost("ObenerPorFiltro")]
        public async Task<IActionResult> ObtenerPorFiltro([FromBody]filtroModel filtro)
        {
            try
            {
                filtroDTO filtrado = new filtroDTO();
                filtrado.autorId = filtro.autorId != null ? filtrado.autorId = Guid.Parse(filtro.autorId) : filtrado.autorId = null;
                filtrado.categoriaId = filtro.categoriaId != null ? filtrado.categoriaId = Guid.Parse(filtro.categoriaId) : filtrado.categoriaId = null;
                filtrado.nombreLibro = filtro.nombreLibro != null ? filtrado.nombreLibro = filtro.nombreLibro : filtrado.nombreLibro = null;
                
                var libros = await _service.FiltrarLibros(filtrado);
                if (libros.Count >= 1)
                {
                    return Ok(LibroConvert.toListModel(libros));
                }
                else
                {
                    return BadRequest("No hay libros registrados que cumplan esos parametros!!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}