using EjercicioWebApiPlatzi.Models;
using EjercicioWebApiPlatzi.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareasController : ControllerBase
    {
        readonly ITareasServicio tareasServicio;


        public TareasController(ITareasServicio servicio)
        {
            tareasServicio = servicio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareasServicio.Get());
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] Tareas agregartareas)
        {
            tareasServicio.Post(agregartareas);
            return Ok(agregartareas);
        }
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody]Tareas modificarTareas)
        {
            tareasServicio.Put(id, modificarTareas);
            return Ok(modificarTareas);
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            tareasServicio.Delete(id);
            return Ok();
        }



    }
}
