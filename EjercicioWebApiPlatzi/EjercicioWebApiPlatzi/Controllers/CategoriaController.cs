using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioWebApiPlatzi.Servicios;
using EjercicioWebApiPlatzi.Models;

namespace EjercicioWebApiPlatzi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        readonly ICategoriaService categoriaServicio;
        public CategoriaController(ICategoriaService service)
        {
            categoriaServicio = service;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriaServicio.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Categoria agregarCategoria)
        {
            categoriaServicio.Post(agregarCategoria);
            return Ok(agregarCategoria);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Categoria modificarCategoria)
        {
            categoriaServicio.Put(id, modificarCategoria);
            return Ok(modificarCategoria);

        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            categoriaServicio.Delete(id);
            return Ok();
        }
    }
}
