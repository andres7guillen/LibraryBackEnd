using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Converts;
using LibraryAPI.Models;
using LibraryDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;

        public AutorController(IAutorService service)
        {
            _service = service;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]AutorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Crear(AutorConvert.toEntity(model));
                    if (result != null)
                    {
                        return Ok(AutorConvert.toModel(result));
                    }
                    else
                    {
                        return BadRequest("Error creando el Autor!!");
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

        [HttpGet("ObtenerPorGuid")]
        public async Task<IActionResult> ObtenerPorGuid(string Id)
        {
            try
            {
                Guid id = Guid.Parse(Id);
                var result = await _service.ObtenerPorGuid(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(AutorConvert.toModel(result));
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
                    return Ok(AutorConvert.toListModel(result));
                }
                else
                {
                    return BadRequest("No hay autores registrados!!!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }           
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]AutorModel autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Actualizar(AutorConvert.toEntity(autor));
                    return Ok(AutorConvert.toModel(result));
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



    }
}